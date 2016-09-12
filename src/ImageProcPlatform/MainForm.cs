using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Threading.Tasks;

//DLL構成の手本
// http://catchval.com/csharp/4232

//画像入手元
// http://www.ess.ic.kanagawa-it.ac.jp/app_images_j.html
// http://www.ess.ic.kanagawa-it.ac.jp/std_img/colorimage/color.zip

namespace ImageProcPlatform
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// 処理前画像
        /// </summary>
        private Image OriginalImage;

        /// <summary>
        /// 画像処理インスタンス
        /// </summary>
        private ImageProc imageProc;

        /// <summary>
        /// 画像処理実行タスクが生成されているか
        /// </summary>
        private static bool isExecIPTaskCreated;

        /// <summary>
        /// IPステータスラベルセットタスクを走らせるか否か
        /// </summary>
        private static bool isSetIPStatusLabelTaskRunning;

        /// <summary>
        /// タスク状態指定子
        /// </summary>
        private enum ETaskStatus
        {
            CREATE_AND_START,
            STOP
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            imageProc = new ImageProc(Path.GetDirectoryName(Application.ExecutablePath));
            
            OriginalImage = Image.FromFile(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), @"SampleImage\Lenna.bmp"));

            //以下、GUI設定
            SetPictureToViewer(OriginalImage);

            ImageProcToolStripProgressBar.Minimum = 0;
            ImageProcToolStripProgressBar.Maximum = 100; //百分率扱いとするので、100で固定

            isExecIPTaskCreated = false;

            {
                string[] imageProcName = imageProc.GetPluginName();
                for (int i = 0; i < imageProcName.Length; i++)
                {
                    ProcImageToolStripComboBox.Items.Add(imageProcName[i]);
                }
                ProcImageToolStripComboBox.Text = (string)ProcImageToolStripComboBox.Items[0];
            }

            SetIPStatusMessage(ETaskStatus.CREATE_AND_START);
        }


        //**イベントハンドラ****************************************************************

        /// <summary>
        /// 開くボタン押下
        /// </summary>
        private void openImageToolStripButton_Click(object sender, EventArgs e)
        {
            OpenImageFile();
        }

        /// <summary>
        /// 名前をつけて保存ボタン押下
        /// </summary>
        private void saveImageToolStripButton_Click(object sender, EventArgs e)
        {
            SaveImageWrap();
        }

        /// <summary>
        /// 画像初期化ボタン押下
        /// </summary>
        private void resetImageToolStripButton_Click(object sender, EventArgs e)
        {
            SetPictureToViewer(OriginalImage);
            MessageBox.Show("画像初期化完了", "Completed.", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// ビューワー上でマウス移動
        /// </summary>
        private void ImageViewerPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePos = new Point(e.X, e.Y);
            SetMousePosText(mousePos);
        }

        /// <summary>
        /// ビューワーからマウス離脱
        /// </summary>
        private void ImageViewerPictureBox_MouseLeave(object sender, EventArgs e)
        {
            MousePosToolStripStatusLabel.Text = "";
        }

        /// <summary>
        /// 画像処理設定ボタン押下
        /// </summary>
        private void ProcImageSettingToolStripButton_Click(object sender, EventArgs e)
        {
            imageProc.SettingIP(ProcImageToolStripComboBox.Text);
        }

        /// <summary>
        /// 画像処理実行ボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProcImageExecToolStripButton_Click(object sender, EventArgs e)
        {
            if (ImageViewerPictureBox.Image == null)
            {
                MessageBox.Show("Image is null.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                goto Finish;
            }

            if (!isExecIPTaskCreated)
            {
                //画処理は時間がかかるため、別タスクをとして動かす
                Task execIPTask = Task.Factory.StartNew(() =>
                {
                    string ipName = ProcImageToolStripComboBox.Text;
                    isExecIPTaskCreated = true;

                    //プログレスバー更新タスクを生成
                    Task updateProgressBarTask = Task.Factory.StartNew(() =>
                        {
                            int prog;

                            while (true)
                            {
                                if( imageProc.GetProgress(ipName, out prog))
                                {
                                    ImageProcToolStripProgressBar.Value = prog;
                                }

                                if (!isExecIPTaskCreated)
                                {
                                    ImageProcToolStripProgressBar.Value = 0;
                                    break;
                                }
                            }
                        });

                    ImageViewerPictureBox.Image = imageProc.ExecIP(ipName, new Bitmap(ImageViewerPictureBox.Image));
                    ImageViewerPictureBox.Size = ImageViewerPictureBox.Image.Size;
                    SetImageSizeToToolStripStatusLabel(ImageViewerPictureBox.Image);

                    ImageProcToolStripProgressBar.Value = 0; //メッセージダイアログが出た時点で0にする
                    Task t = Task.Factory.StartNew(() =>
                    {
                        MessageBox.Show("Image Proc finished.", "Information.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    });

                    isExecIPTaskCreated = false;
                });
            }
            else
            {
                MessageBox.Show("Image proccessing has already executed.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        Finish:
            return;
        }



        //**内部処理****************************************************************

        /// <summary>
        /// マウス座標ラベルをセット
        /// </summary>
        /// <param name="mousePos">マウス座標</param>
        private void SetMousePosText(Point mousePos)
        {
            if (mousePos.IsEmpty || MousePosToolStripStatusLabel == null)
            {
                goto Finish;
            }

            MousePosToolStripStatusLabel.Text = mousePos.X.ToString() + ", " + mousePos.Y.ToString() + "px";

        Finish:
            return;
        }

        /// <summary>
        /// オープンファイルダイアログから画像を指定し、OriginalImageに画像をロードする
        /// </summary>
        private void OpenImageFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "すべてのファイル(*.*)|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //MessageBox.Show(ofd.FileName);
                OriginalImage = LoadImage(ofd.FileName);
                if (OriginalImage == null)
                {
                    goto Finish;
                }

                SetPictureToViewer(OriginalImage);
            }

        Finish:
            return;
        }

        /// <summary>
        /// LoadImageメソッドのラッパー
        /// </summary>
        /// <param name="filePath">画像ファイルパス</param>
        /// <returns>ロードした画像</returns>
        private Image LoadImageWrap(string filePath)
        {
            Image loadedImage = LoadImage(filePath);
            if (loadedImage == null)
            {
                MessageBox.Show("Load Image failed.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                goto Failed;
            }

            return loadedImage;

        Failed:
            return null;
        }

        /// <summary>
        /// ファイルパスから画像をロードして、Imageとしてreturnするだけのメソッド
        /// </summary>
        /// <param name="filePath">画像ファイルパス</param>
        /// <returns>ロードした画像</returns>
        private Image LoadImage(string filePath)
        {
            Image retImage;
            if (!System.IO.File.Exists(@filePath))
            {
                return null;
            }

            try
            {
                retImage = Image.FromFile(@filePath);
            }
            catch (OutOfMemoryException)
            {
                MessageBox.Show("Loading Image error.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            return retImage;
        }

        /// <summary>
        /// ビューワーに画像を設定する
        /// </summary>
        /// <param name="image">設定する画像</param>
        private void SetPictureToViewer(Image image)
        {
            if (image == null)
            {
                MessageBox.Show("Image is null.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                goto Finish;
            }

            if (ImageViewerPictureBox.Image != null)
            {
                ImageViewerPictureBox.Image.Dispose();
            }

            ImageViewerPictureBox.Image = (Image)image.Clone();
            ImageViewerPictureBox.Size = image.Size;

            SetImageSizeToToolStripStatusLabel(image);

        Finish:
            return;
        }

        /// <summary>
        /// 画像サイズをラベルに設定
        /// </summary>
        /// <param name="image">設定する画像情報</param>
        private void SetImageSizeToToolStripStatusLabel(Image image)
        {
            if (image == null)
            {
                goto Finish;
            }
            if (image.Size.IsEmpty)
            {
                goto Finish;
            }
            ImageSizeToolStripStatusLabel.Text = image.Size.Width.ToString() + " x " + image.Size.Height.ToString() + " px";

        Finish:
            return;
        }

        /// <summary>
        /// 画像保存ラッパー
        /// </summary>
        private void SaveImageWrap()
        {
            if (ImageViewerPictureBox.Image == null)
            {
                MessageBox.Show("Image is null.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                goto Finish;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "すべてのファイル(*.*)|*.*";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //MessageBox.Show(sfd.FileName);
                if (SaveImage(ImageViewerPictureBox.Image, sfd.FileName))
                {
                    if (MessageBox.Show("Save Image succeeded.\nDo you set viewing image as \"Original Image\" ?", "Succeeded.",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        OriginalImage.Dispose();
                        OriginalImage = ImageViewerPictureBox.Image;
                    }
                }
            }

        Finish:
            return;
        }

        /// <summary>
        /// ファイルパスに画像を保存するメソッド
        /// </summary>
        /// <param name="image">保存する画像</param>
        /// <param name="filePath">画像保存パス</param>
        /// <returns>true:画像保存成功 false:画像保存失敗</returns>
        private bool SaveImage(Image image, string filePath)
        {
            if (image == null)
            {
                goto Failed;
            }
            image.Save(filePath);

            return true;

        Failed:
            return false;
        }

        /// <summary>
        /// IPステータス文字列をセットする
        /// </summary>
        private void SetIPStatusMessage(ETaskStatus ts)
        {
            switch (ts)
            {
                case ETaskStatus.CREATE_AND_START:
                    isSetIPStatusLabelTaskRunning = true;
                    Task IPStatusMessageTask = Task.Factory.StartNew(() =>
                    {
                        while (isSetIPStatusLabelTaskRunning)
                        {
                            IPStatusToolStripStatusLabel.Text = imageProc.status;
                        }
                    });
                    break;
                case ETaskStatus.STOP:
                    isSetIPStatusLabelTaskRunning = false;
                    break;
            }
        }
    }
}

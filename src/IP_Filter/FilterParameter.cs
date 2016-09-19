using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IP_Filter.Parameter
{
    public class FilterParameter
    {
        /// <summary>
        /// true:有効
        /// false:無効
        /// </summary>
        public bool isEnabled;

        /// <summary>
        /// フィルターの一辺のサイズ。
        /// 奇数。
        /// </summary>
        public int FilterSize;

        /// <summary>
        /// フィルター本体
        /// </summary>
        public double[,] FilterArray;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="size">フィルターサイズ初期値</param>
        public FilterParameter(int size)
        {
            FilterSize = size;
            FilterArray = new double[FilterSize,FilterSize];

            for (int i = 0; i < FilterSize; i++)
            {
                for (int j = 0; j < FilterSize; j++)
                {
                    FilterArray[i, j] = 1.0;
                }
            }
        }
    }
}

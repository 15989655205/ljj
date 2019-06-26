using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maticsoft.Model
{
    /// <summary>
    /// v_ProductColor:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class v_ProductColor
    {
        public v_ProductColor()
        { }
        #region Model
        private long _id;
        private long? _pid;
        private string _colorcode;
        private string _colorname;
        private decimal? _cbarginpriceout;
        private decimal? _cstandardpricein;
        private decimal? _ctagprice;
        private decimal? _creferencepricea;
        private decimal? _creferencepriceb;
        private decimal? _creferencepricec;
        private decimal? _creferencepriced;
        private decimal? _creferencepricee;
        private decimal? _creferencepricef;
        private string _member;
        private string _pcode;
        private string _pname;
        private long? _seriesid;
        private long? _typeid;
        private string _manufacturer;
        /// <summary>
        /// 
        /// </summary>
        public long ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? pid
        {
            set { _pid = value; }
            get { return _pid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ColorCode
        {
            set { _colorcode = value; }
            get { return _colorcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ColorName
        {
            set { _colorname = value; }
            get { return _colorname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? CBarginPriceOut
        {
            set { _cbarginpriceout = value; }
            get { return _cbarginpriceout; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? CStandardPriceIn
        {
            set { _cstandardpricein = value; }
            get { return _cstandardpricein; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? CTagPrice
        {
            set { _ctagprice = value; }
            get { return _ctagprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? CReferencePriceA
        {
            set { _creferencepricea = value; }
            get { return _creferencepricea; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? CReferencePriceB
        {
            set { _creferencepriceb = value; }
            get { return _creferencepriceb; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? CReferencePriceC
        {
            set { _creferencepricec = value; }
            get { return _creferencepricec; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? CReferencePriceD
        {
            set { _creferencepriced = value; }
            get { return _creferencepriced; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? CReferencePriceE
        {
            set { _creferencepricee = value; }
            get { return _creferencepricee; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? CReferencePriceF
        {
            set { _creferencepricef = value; }
            get { return _creferencepricef; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string member
        {
            set { _member = value; }
            get { return _member; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PCode
        {
            set { _pcode = value; }
            get { return _pcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PName
        {
            set { _pname = value; }
            get { return _pname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? SeriesID
        {
            set { _seriesid = value; }
            get { return _seriesid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? TypeID
        {
            set { _typeid = value; }
            get { return _typeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Manufacturer
        {
            set { _manufacturer = value; }
            get { return _manufacturer; }
        }
        #endregion Model

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maticsoft.Model
{
    public partial class ProjectProductStage
    {
        private int? _sid;
        private string _ProductID="";
        private string _number = "";
        private string _useSpace = "";
        private string _usePart = "";
        private string _unit = "";
        private string _install = "";
        private decimal _amount=0;
        private decimal _spaceCount = 1;
        private string _EndProduct = "";
        private string _paintColor = "";
        private string _remark = "";
  public string PaintColor
        {
            get { return _paintColor; }
            set { _paintColor = value; }
        }
        public int? sid
        {
            set { _sid = value; }
            get { return _sid; }
        }

        public string ProductID
		{
			set{ _ProductID=value;}
			get{return _ProductID;}
		}

        public string number
        {
            set { _number = value; }
            get { return _number; }
        }

        public string useSpace
        {
            set { _useSpace = value; }
            get { return _useSpace; }
        }

        public string usePart
        {
            set { _usePart = value; }
            get { return _usePart; }
        }

        public string unit
        {
            set { _unit = value; }
            get { return _unit; }
        }
        public string install
        {
            set { _install = value; }
            get { return _install; }
        }
        public decimal spaceCount
        {
            set { _spaceCount = value; }
            get { return _spaceCount; }
        }

        public decimal amount
        {
            set { _amount = value; }
            get { return _amount; }
        }
        public string EndProduct
        {
            set { _EndProduct = value; }
            get { return _EndProduct; }
        }
        public string remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
    }
}

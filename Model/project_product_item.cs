using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// project_product_item:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class project_product_item
	{
		public project_product_item()
		{}
		#region Model
		private int _sid;
		private int? _parentid;
		private int? _productid;
		private string _number;
		private string _name;
		private string _projectname;
		private string _pic;
		private string _size;
		private string _paintcolor;
		private string _usespace;
		private int _spacecount=1;
		private string _install;
		private string _usepart;
		private string _unit;
		private int _amount=0;
		private string _paintpalettenumber;
		private string _endproduct;


     
		private int? _sequence;
		private int? _state;
		private string _remark;
		private string _v1;
		private string _v2;
		private string _v3;
		private string _v4;
		private string _v5;
		private string _v6;
		private string _v7;
		private string _v8;
		private string _v9;
		private string _v10;
		private string _create_person;
		private DateTime? _create_date;
		private string _update_person;
		private DateTime? _update_date;
        private int _pp_sid;

		/// <summary>
		/// 
		/// </summary>
		public int sid
		{
			set{ _sid=value;}
			get{return _sid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? parentID
		{
			set{ _parentid=value;}
			get{return _parentid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ProductID
		{
			set{ _productid=value;}
			get{return _productid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string number
		{
			set{ _number=value;}
			get{return _number;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string projectName
		{
			set{ _projectname=value;}
			get{return _projectname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string pic
		{
			set{ _pic=value;}
			get{return _pic;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string size
		{
			set{ _size=value;}
			get{return _size;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string paintColor
		{
			set{ _paintcolor=value;}
			get{return _paintcolor;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string useSpace
		{
			set{ _usespace=value;}
			get{return _usespace;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int spaceCount
		{
			set{ _spacecount=value;}
			get{return _spacecount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string install
		{
			set{ _install=value;}
			get{return _install;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string usePart
		{
			set{ _usepart=value;}
			get{return _usepart;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string unit
		{
			set{ _unit=value;}
			get{return _unit;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int amount
		{
			set{ _amount=value;}
			get{return _amount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string paintPaletteNumber
		{
			set{ _paintpalettenumber=value;}
			get{return _paintpalettenumber;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string EndProduct
		{
			set{ _endproduct=value;}
			get{return _endproduct;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? sequence
		{
			set{ _sequence=value;}
			get{return _sequence;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? state
		{
			set{ _state=value;}
			get{return _state;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string v1
		{
			set{ _v1=value;}
			get{return _v1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string v2
		{
			set{ _v2=value;}
			get{return _v2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string v3
		{
			set{ _v3=value;}
			get{return _v3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string v4
		{
			set{ _v4=value;}
			get{return _v4;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string v5
		{
			set{ _v5=value;}
			get{return _v5;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string v6
		{
			set{ _v6=value;}
			get{return _v6;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string v7
		{
			set{ _v7=value;}
			get{return _v7;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string v8
		{
			set{ _v8=value;}
			get{return _v8;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string v9
		{
			set{ _v9=value;}
			get{return _v9;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string v10
		{
			set{ _v10=value;}
			get{return _v10;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string create_person
		{
			set{ _create_person=value;}
			get{return _create_person;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? create_date
		{
			set{ _create_date=value;}
			get{return _create_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string update_person
		{
			set{ _update_person=value;}
			get{return _update_person;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? update_date
		{
			set{ _update_date=value;}
			get{return _update_date;}
		}
		#endregion Model

	}
}


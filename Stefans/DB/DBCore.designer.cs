﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18449
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DB
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Stefans")]
	public partial class DBCoreDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public DBCoreDataContext() : 
				base(global::DB.Properties.Settings.Default.StefansConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DBCoreDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DBCoreDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DBCoreDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DBCoreDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.UM_tsp_Users")]
		public int UM_tsp_Users([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="TinyInt")] System.Nullable<byte> iud, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="UserID", DbType="Int")] ref System.Nullable<int> userID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Password", DbType="NVarChar(200)")] string password, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="FirstName", DbType="NVarChar(100)")] string firstName, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="LastName", DbType="NVarChar(100)")] string lastName, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Email", DbType="VarChar(500)")] string email, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Phone", DbType="VarChar(50)")] string phone, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Address1", DbType="NVarChar(200)")] string address1, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Address2", DbType="NVarChar(200)")] string address2, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="StateID", DbType="Int")] System.Nullable<int> stateID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Zip", DbType="VarChar(10)")] string zip, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="City", DbType="NVarChar(100)")] string city, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IsActive", DbType="Bit")] System.Nullable<bool> isActive)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), iud, userID, password, firstName, lastName, email, phone, address1, address2, stateID, zip, city, isActive);
			userID = ((System.Nullable<int>)(result.GetParameterValue(1)));
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.IsEmailUnique", IsComposable=true)]
		public System.Nullable<bool> IsEmailUnique([global::System.Data.Linq.Mapping.ParameterAttribute(Name="Email", DbType="NVarChar(100)")] string email, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="UserID", DbType="Int")] System.Nullable<int> userID)
		{
			return ((System.Nullable<bool>)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), email, userID).ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.List_Dictionaries", IsComposable=true)]
		public IQueryable<List_DictionariesResult> List_Dictionaries([global::System.Data.Linq.Mapping.ParameterAttribute(Name="Level", DbType="Int")] System.Nullable<int> level, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="DictionaryCode", DbType="Int")] System.Nullable<int> dictionaryCode, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ShowInvisibleItems", DbType="Bit")] System.Nullable<bool> showInvisibleItems)
		{
			return this.CreateMethodCallQuery<List_DictionariesResult>(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), level, dictionaryCode, showInvisibleItems);
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.UM_GetSingle_User", IsComposable=true)]
		public System.Xml.Linq.XElement UM_GetSingle_User([global::System.Data.Linq.Mapping.ParameterAttribute(Name="UserID", DbType="Int")] System.Nullable<int> userID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Email", DbType="VarChar(500)")] string email)
		{
			return ((System.Xml.Linq.XElement)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), userID, email).ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.tx_Products")]
		public int tx_Products([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="TinyInt")] System.Nullable<byte> iud, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Xml")] System.Xml.Linq.XElement x, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="out", DbType="Xml")] ref System.Xml.Linq.XElement @out)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), iud, x, @out);
			@out = ((System.Xml.Linq.XElement)(result.GetParameterValue(2)));
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.tsp_Products")]
		public int tsp_Products([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="TinyInt")] System.Nullable<byte> iud, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ProductID", DbType="Int")] ref System.Nullable<int> productID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Caption", DbType="NVarChar(200)")] string caption, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Description", DbType="NVarChar(1000)")] string description, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Image", DbType="NVarChar(100)")] string image, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Price", DbType="Money")] System.Nullable<decimal> price, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Instructions", DbType="NVarChar(1000)")] string instructions)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), iud, productID, caption, description, image, price, instructions);
			productID = ((System.Nullable<int>)(result.GetParameterValue(1)));
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.tsp_ProductTestimonials")]
		public int tsp_ProductTestimonials([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="TinyInt")] System.Nullable<byte> iud, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="RecordID", DbType="Int")] ref System.Nullable<int> recordID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ProductID", DbType="Int")] System.Nullable<int> productID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Name", DbType="NVarChar(200)")] string name, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Description", DbType="NVarChar(2000)")] string description)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), iud, recordID, productID, name, description);
			recordID = ((System.Nullable<int>)(result.GetParameterValue(1)));
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.GetSingle_ProductTestimonial", IsComposable=true)]
		public System.Xml.Linq.XElement GetSingle_ProductTestimonial([global::System.Data.Linq.Mapping.ParameterAttribute(Name="RecordID", DbType="Int")] System.Nullable<int> recordID)
		{
			return ((System.Xml.Linq.XElement)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), recordID).ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.List_ProductTestimonials", IsComposable=true)]
		public IQueryable<List_ProductTestimonialsResult> List_ProductTestimonials()
		{
			return this.CreateMethodCallQuery<List_ProductTestimonialsResult>(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.List_Products", IsComposable=true)]
		public IQueryable<List_ProductsResult> List_Products()
		{
			return this.CreateMethodCallQuery<List_ProductsResult>(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.GetSingle_Product", IsComposable=true)]
		public System.Xml.Linq.XElement GetSingle_Product([global::System.Data.Linq.Mapping.ParameterAttribute(Name="ProductID", DbType="Int")] System.Nullable<int> productID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IncludeTestimonials", DbType="Bit")] System.Nullable<bool> includeTestimonials)
		{
			return ((System.Xml.Linq.XElement)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), productID, includeTestimonials).ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.tsp_Favourites")]
		public int tsp_Favourites([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="TinyInt")] System.Nullable<byte> iud, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="FavouriteID", DbType="Int")] ref System.Nullable<int> favouriteID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="UserID", DbType="Int")] System.Nullable<int> userID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ProductID", DbType="Int")] System.Nullable<int> productID)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), iud, favouriteID, userID, productID);
			favouriteID = ((System.Nullable<int>)(result.GetParameterValue(1)));
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.List_Favourites", IsComposable=true)]
		public IQueryable<List_FavouritesResult> List_Favourites([global::System.Data.Linq.Mapping.ParameterAttribute(Name="UserID", DbType="Int")] System.Nullable<int> userID)
		{
			return this.CreateMethodCallQuery<List_FavouritesResult>(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), userID);
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.tsp_CartItems")]
		public int tsp_CartItems([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="TinyInt")] System.Nullable<byte> iud, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="CartItemID", DbType="Int")] ref System.Nullable<int> cartItemID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="UserID", DbType="Int")] System.Nullable<int> userID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ProductID", DbType="Int")] System.Nullable<int> productID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Quantity", DbType="Int")] System.Nullable<int> quantity)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), iud, cartItemID, userID, productID, quantity);
			cartItemID = ((System.Nullable<int>)(result.GetParameterValue(1)));
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.List_CartItems", IsComposable=true)]
		public IQueryable<List_CartItemsResult> List_CartItems([global::System.Data.Linq.Mapping.ParameterAttribute(Name="UserID", DbType="Int")] System.Nullable<int> userID)
		{
			return this.CreateMethodCallQuery<List_CartItemsResult>(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), userID);
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.tsp_ADNTransactions")]
		public int tsp_ADNTransactions([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="TinyInt")] System.Nullable<byte> iud, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="RecordID", DbType="Int")] ref System.Nullable<int> recordID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="UserID", DbType="Int")] System.Nullable<int> userID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="OrderID", DbType="Int")] System.Nullable<int> orderID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ADNTransactionID", DbType="BigInt")] System.Nullable<long> aDNTransactionID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="RequestStr", DbType="NVarChar(MAX)")] string requestStr, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ResponseStr", DbType="NVarChar(MAX)")] string responseStr)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), iud, recordID, userID, orderID, aDNTransactionID, requestStr, responseStr);
			recordID = ((System.Nullable<int>)(result.GetParameterValue(1)));
			return ((int)(result.ReturnValue));
		}
	}
	
	public partial class List_DictionariesResult
	{
		
		private System.Nullable<long> _RowNum;
		
		private int _DictionaryID;
		
		private System.Guid _uid;
		
		private string _Caption;
		
		private string _Caption1;
		
		private System.Nullable<int> _CodeVal;
		
		private System.Nullable<int> _ParentID;
		
		private System.Nullable<short> _Level;
		
		private string _Hierarchy;
		
		private string _StringCode;
		
		private short _DictionaryCode;
		
		private System.Nullable<bool> _DefVal;
		
		private System.Nullable<bool> _Visible;
		
		private System.Nullable<int> _SortVal;
		
		private System.Nullable<decimal> _DecimalVal;
		
		private System.DateTime _CRTime;
		
		public List_DictionariesResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RowNum", DbType="BigInt")]
		public System.Nullable<long> RowNum
		{
			get
			{
				return this._RowNum;
			}
			set
			{
				if ((this._RowNum != value))
				{
					this._RowNum = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DictionaryID", DbType="Int NOT NULL")]
		public int DictionaryID
		{
			get
			{
				return this._DictionaryID;
			}
			set
			{
				if ((this._DictionaryID != value))
				{
					this._DictionaryID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_uid", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid uid
		{
			get
			{
				return this._uid;
			}
			set
			{
				if ((this._uid != value))
				{
					this._uid = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Caption", DbType="NVarChar(200)")]
		public string Caption
		{
			get
			{
				return this._Caption;
			}
			set
			{
				if ((this._Caption != value))
				{
					this._Caption = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Caption1", DbType="NVarChar(200)")]
		public string Caption1
		{
			get
			{
				return this._Caption1;
			}
			set
			{
				if ((this._Caption1 != value))
				{
					this._Caption1 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CodeVal", DbType="Int")]
		public System.Nullable<int> CodeVal
		{
			get
			{
				return this._CodeVal;
			}
			set
			{
				if ((this._CodeVal != value))
				{
					this._CodeVal = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ParentID", DbType="Int")]
		public System.Nullable<int> ParentID
		{
			get
			{
				return this._ParentID;
			}
			set
			{
				if ((this._ParentID != value))
				{
					this._ParentID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Level]", Storage="_Level", DbType="SmallInt")]
		public System.Nullable<short> Level
		{
			get
			{
				return this._Level;
			}
			set
			{
				if ((this._Level != value))
				{
					this._Level = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Hierarchy", DbType="VarChar(200)")]
		public string Hierarchy
		{
			get
			{
				return this._Hierarchy;
			}
			set
			{
				if ((this._Hierarchy != value))
				{
					this._Hierarchy = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StringCode", DbType="NVarChar(100)")]
		public string StringCode
		{
			get
			{
				return this._StringCode;
			}
			set
			{
				if ((this._StringCode != value))
				{
					this._StringCode = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DictionaryCode", DbType="SmallInt NOT NULL")]
		public short DictionaryCode
		{
			get
			{
				return this._DictionaryCode;
			}
			set
			{
				if ((this._DictionaryCode != value))
				{
					this._DictionaryCode = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DefVal", DbType="Bit")]
		public System.Nullable<bool> DefVal
		{
			get
			{
				return this._DefVal;
			}
			set
			{
				if ((this._DefVal != value))
				{
					this._DefVal = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Visible", DbType="Bit")]
		public System.Nullable<bool> Visible
		{
			get
			{
				return this._Visible;
			}
			set
			{
				if ((this._Visible != value))
				{
					this._Visible = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SortVal", DbType="Int")]
		public System.Nullable<int> SortVal
		{
			get
			{
				return this._SortVal;
			}
			set
			{
				if ((this._SortVal != value))
				{
					this._SortVal = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DecimalVal", DbType="Money")]
		public System.Nullable<decimal> DecimalVal
		{
			get
			{
				return this._DecimalVal;
			}
			set
			{
				if ((this._DecimalVal != value))
				{
					this._DecimalVal = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CRTime", DbType="DateTime NOT NULL")]
		public System.DateTime CRTime
		{
			get
			{
				return this._CRTime;
			}
			set
			{
				if ((this._CRTime != value))
				{
					this._CRTime = value;
				}
			}
		}
	}
	
	public partial class List_ProductTestimonialsResult
	{
		
		private int _RecordID;
		
		private int _ProductID;
		
		private string _Name;
		
		private string _Description;
		
		private System.DateTime _CRTime;
		
		private string _ProductCaption;
		
		public List_ProductTestimonialsResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RecordID", DbType="Int NOT NULL")]
		public int RecordID
		{
			get
			{
				return this._RecordID;
			}
			set
			{
				if ((this._RecordID != value))
				{
					this._RecordID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProductID", DbType="Int NOT NULL")]
		public int ProductID
		{
			get
			{
				return this._ProductID;
			}
			set
			{
				if ((this._ProductID != value))
				{
					this._ProductID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(200) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this._Name = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Description", DbType="NVarChar(2000) NOT NULL", CanBeNull=false)]
		public string Description
		{
			get
			{
				return this._Description;
			}
			set
			{
				if ((this._Description != value))
				{
					this._Description = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CRTime", DbType="DateTime NOT NULL")]
		public System.DateTime CRTime
		{
			get
			{
				return this._CRTime;
			}
			set
			{
				if ((this._CRTime != value))
				{
					this._CRTime = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProductCaption", DbType="NVarChar(200) NOT NULL", CanBeNull=false)]
		public string ProductCaption
		{
			get
			{
				return this._ProductCaption;
			}
			set
			{
				if ((this._ProductCaption != value))
				{
					this._ProductCaption = value;
				}
			}
		}
	}
	
	public partial class List_ProductsResult
	{
		
		private int _ProductID;
		
		private string _Caption;
		
		private string _Description;
		
		private string _Image;
		
		private decimal _Price;
		
		private string _Instructions;
		
		private bool _IsFeature;
		
		private System.DateTime _CRTime;
		
		public List_ProductsResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProductID", DbType="Int NOT NULL")]
		public int ProductID
		{
			get
			{
				return this._ProductID;
			}
			set
			{
				if ((this._ProductID != value))
				{
					this._ProductID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Caption", DbType="NVarChar(200) NOT NULL", CanBeNull=false)]
		public string Caption
		{
			get
			{
				return this._Caption;
			}
			set
			{
				if ((this._Caption != value))
				{
					this._Caption = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Description", DbType="NVarChar(1000) NOT NULL", CanBeNull=false)]
		public string Description
		{
			get
			{
				return this._Description;
			}
			set
			{
				if ((this._Description != value))
				{
					this._Description = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Image", DbType="NVarChar(100)")]
		public string Image
		{
			get
			{
				return this._Image;
			}
			set
			{
				if ((this._Image != value))
				{
					this._Image = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Price", DbType="Money NOT NULL")]
		public decimal Price
		{
			get
			{
				return this._Price;
			}
			set
			{
				if ((this._Price != value))
				{
					this._Price = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Instructions", DbType="NVarChar(1000)")]
		public string Instructions
		{
			get
			{
				return this._Instructions;
			}
			set
			{
				if ((this._Instructions != value))
				{
					this._Instructions = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsFeature", DbType="Bit NOT NULL")]
		public bool IsFeature
		{
			get
			{
				return this._IsFeature;
			}
			set
			{
				if ((this._IsFeature != value))
				{
					this._IsFeature = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CRTime", DbType="DateTime NOT NULL")]
		public System.DateTime CRTime
		{
			get
			{
				return this._CRTime;
			}
			set
			{
				if ((this._CRTime != value))
				{
					this._CRTime = value;
				}
			}
		}
	}
	
	public partial class List_FavouritesResult
	{
		
		private int _ProductID;
		
		private string _Caption;
		
		private string _Image;
		
		private decimal _Price;
		
		public List_FavouritesResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProductID", DbType="Int NOT NULL")]
		public int ProductID
		{
			get
			{
				return this._ProductID;
			}
			set
			{
				if ((this._ProductID != value))
				{
					this._ProductID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Caption", DbType="NVarChar(200) NOT NULL", CanBeNull=false)]
		public string Caption
		{
			get
			{
				return this._Caption;
			}
			set
			{
				if ((this._Caption != value))
				{
					this._Caption = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Image", DbType="NVarChar(100)")]
		public string Image
		{
			get
			{
				return this._Image;
			}
			set
			{
				if ((this._Image != value))
				{
					this._Image = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Price", DbType="Money NOT NULL")]
		public decimal Price
		{
			get
			{
				return this._Price;
			}
			set
			{
				if ((this._Price != value))
				{
					this._Price = value;
				}
			}
		}
	}
	
	public partial class List_CartItemsResult
	{
		
		private int _Quantity;
		
		private int _ProductID;
		
		private decimal _Price;
		
		private string _Caption;
		
		private string _Image;
		
		public List_CartItemsResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Quantity", DbType="Int NOT NULL")]
		public int Quantity
		{
			get
			{
				return this._Quantity;
			}
			set
			{
				if ((this._Quantity != value))
				{
					this._Quantity = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProductID", DbType="Int NOT NULL")]
		public int ProductID
		{
			get
			{
				return this._ProductID;
			}
			set
			{
				if ((this._ProductID != value))
				{
					this._ProductID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Price", DbType="Money NOT NULL")]
		public decimal Price
		{
			get
			{
				return this._Price;
			}
			set
			{
				if ((this._Price != value))
				{
					this._Price = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Caption", DbType="NVarChar(200) NOT NULL", CanBeNull=false)]
		public string Caption
		{
			get
			{
				return this._Caption;
			}
			set
			{
				if ((this._Caption != value))
				{
					this._Caption = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Image", DbType="NVarChar(100)")]
		public string Image
		{
			get
			{
				return this._Image;
			}
			set
			{
				if ((this._Image != value))
				{
					this._Image = value;
				}
			}
		}
	}
}
#pragma warning restore 1591

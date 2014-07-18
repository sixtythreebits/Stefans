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
	public partial class DBUMDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public DBUMDataContext() : 
				base(global::DB.Properties.Settings.Default.StefansConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DBUMDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DBUMDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DBUMDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DBUMDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
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
	}
}
#pragma warning restore 1591

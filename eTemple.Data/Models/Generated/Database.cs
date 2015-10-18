
// This file was automatically generated by the PetaPoco T4 Template
// Do not make changes directly to this file - edit the template instead
// 
// The following connection settings were used to generate this file
// 
//     Connection String Name: `eTempleDb`
//     Provider:               `MySql.Data.MySqlClient`
//     Connection String:      `Server=localhost;Database=etemplevinayak;Uid=etempleuser;Pwd=etemple;`
//     Schema:                 ``
//     Include Views:          `False`

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PetaPoco;

namespace eTemple.Data.Models
{
	public partial class eTempleDbDB : Database
	{
		public eTempleDbDB() 
			: base("eTempleDb")
		{
			CommonConstruct();
		}

		public eTempleDbDB(string connectionStringName) 
			: base(connectionStringName)
		{
			CommonConstruct();
		}
		
		partial void CommonConstruct();
		
		public interface IFactory
		{
			eTempleDbDB GetInstance();
		}
		
		public static IFactory Factory { get; set; }
        public static eTempleDbDB GetInstance()
        {
			if (_instance!=null)
				return _instance;
				
			if (Factory!=null)
				return Factory.GetInstance();
			else
				return new eTempleDbDB();
        }

		[ThreadStatic] static eTempleDbDB _instance;
		
		public override void OnBeginTransaction()
		{
			if (_instance==null)
				_instance=this;
		}
		
		public override void OnEndTransaction()
		{
			if (_instance==this)
				_instance=null;
		}
        
		public class Record<T> where T:new()
		{
			public static eTempleDbDB repo { get { return eTempleDbDB.GetInstance(); } }
			public bool IsNew() { return repo.IsNew(this); }
			public object Insert() { return repo.Insert(this); }
			public void Save() { repo.Save(this); }
			public int Update() { return repo.Update(this); }
			public int Update(IEnumerable<string> columns) { return repo.Update(this, columns); }
			public static int Update(string sql, params object[] args) { return repo.Update<T>(sql, args); }
			public static int Update(Sql sql) { return repo.Update<T>(sql); }
			public int Delete() { return repo.Delete(this); }
			public static int Delete(string sql, params object[] args) { return repo.Delete<T>(sql, args); }
			public static int Delete(Sql sql) { return repo.Delete<T>(sql); }
			public static int Delete(object primaryKey) { return repo.Delete<T>(primaryKey); }
			public static bool Exists(object primaryKey) { return repo.Exists<T>(primaryKey); }
			public static bool Exists(string sql, params object[] args) { return repo.Exists<T>(sql, args); }
			public static T SingleOrDefault(object primaryKey) { return repo.SingleOrDefault<T>(primaryKey); }
			public static T SingleOrDefault(string sql, params object[] args) { return repo.SingleOrDefault<T>(sql, args); }
			public static T SingleOrDefault(Sql sql) { return repo.SingleOrDefault<T>(sql); }
			public static T FirstOrDefault(string sql, params object[] args) { return repo.FirstOrDefault<T>(sql, args); }
			public static T FirstOrDefault(Sql sql) { return repo.FirstOrDefault<T>(sql); }
			public static T Single(object primaryKey) { return repo.Single<T>(primaryKey); }
			public static T Single(string sql, params object[] args) { return repo.Single<T>(sql, args); }
			public static T Single(Sql sql) { return repo.Single<T>(sql); }
			public static T First(string sql, params object[] args) { return repo.First<T>(sql, args); }
			public static T First(Sql sql) { return repo.First<T>(sql); }
			public static List<T> Fetch(string sql, params object[] args) { return repo.Fetch<T>(sql, args); }
			public static List<T> Fetch(Sql sql) { return repo.Fetch<T>(sql); }
			public static List<T> Fetch(long page, long itemsPerPage, string sql, params object[] args) { return repo.Fetch<T>(page, itemsPerPage, sql, args); }
			public static List<T> Fetch(long page, long itemsPerPage, Sql sql) { return repo.Fetch<T>(page, itemsPerPage, sql); }
			public static List<T> SkipTake(long skip, long take, string sql, params object[] args) { return repo.SkipTake<T>(skip, take, sql, args); }
			public static List<T> SkipTake(long skip, long take, Sql sql) { return repo.SkipTake<T>(skip, take, sql); }
			public static Page<T> Page(long page, long itemsPerPage, string sql, params object[] args) { return repo.Page<T>(page, itemsPerPage, sql, args); }
			public static Page<T> Page(long page, long itemsPerPage, Sql sql) { return repo.Page<T>(page, itemsPerPage, sql); }
			public static IEnumerable<T> Query(string sql, params object[] args) { return repo.Query<T>(sql, args); }
			public static IEnumerable<T> Query(Sql sql) { return repo.Query<T>(sql); }
		}
	}
	

    
	[TableName("dailyannadanam")]
	[PrimaryKey("Id")]
	[ExplicitColumns]
    public partial class dailyannadanam : eTempleDbDB.Record<dailyannadanam>  
    {
		[Column] public int Id { get; set; }
		[Column] public string Name { get; set; }
		[Column] public string PhoneNumber { get; set; }
		[Column] public string Gothram { get; set; }
		[Column] public string VillageName { get; set; }
		[Column] public string DonatedDate { get; set; }
	}
    
	[TableName("datetype")]
	[PrimaryKey("Id", autoIncrement=false)]
	[ExplicitColumns]
    public partial class datetype : eTempleDbDB.Record<datetype>  
    {
		[Column] public int Id { get; set; }
		[Column] public string Name { get; set; }
	}
    
	[TableName("designations")]
	[PrimaryKey("Id")]
	[ExplicitColumns]
    public partial class designation : eTempleDbDB.Record<designation>  
    {
		[Column] public int Id { get; set; }
		[Column] public string Name { get; set; }
	}
    
	[TableName("donors")]
	[PrimaryKey("Id", autoIncrement=false)]
	[ExplicitColumns]
    public partial class donor : eTempleDbDB.Record<donor>  
    {
		[Column] public string Id { get; set; }
		[Column] public DateTime Donordate { get; set; }
		[Column] public string DoorNo { get; set; }
		[Column] public string Surname { get; set; }
		[Column] public string DonorName { get; set; }
		[Column] public string DistrictName { get; set; }
		[Column] public string City { get; set; }
		[Column] public string Pin { get; set; }
		[Column] public string State { get; set; }
		[Column] public string Country { get; set; }
		[Column] public string NameOn { get; set; }
		[Column] public int? Star { get; set; }
		[Column] public string occasion { get; set; }
		[Column] public string Gothram { get; set; }
		[Column] public decimal Amount { get; set; }
		[Column] public string MR_No { get; set; }
		[Column] public string Remarks { get; set; }
		[Column] public string Landline { get; set; }
		[Column] public int? SpecialDayId { get; set; }
		[Column] public int? ServiceTypeId { get; set; }
		[Column] public int? ServiceNameId { get; set; }
		[Column] public int? DateTypeId { get; set; }
		[Column] public string PerformDate { get; set; }
		[Column] public string EmailId { get; set; }
		[Column] public int? DonorMonth { get; set; }
		[Column] public int? Thidhi { get; set; }
		[Column] public int? DonorDay { get; set; }
		[Column] public string Mobile { get; set; }
		[Column] public int? DonorThithi { get; set; }
		[Column] public string Mandal { get; set; }
		[Column] public int? TransactionTypeId { get; set; }
		[Column] public string TransactionID { get; set; }
		[Column] public string TransactionDate { get; set; }
		[Column] public int? CreatedBy { get; set; }
		[Column] public int? ModifiedBy { get; set; }
		[Column] public DateTime? ModifiedDate { get; set; }
	}
    
	[TableName("donors_backup")]
	[PrimaryKey("Id", autoIncrement=false)]
	[ExplicitColumns]
    public partial class donors_backup : eTempleDbDB.Record<donors_backup>  
    {
		[Column] public int Id { get; set; }
		[Column] public DateTime date { get; set; }
		[Column] public string Address { get; set; }
		[Column] public string Surname { get; set; }
		[Column] public string Name { get; set; }
		[Column] public string DistrictName { get; set; }
		[Column] public string City { get; set; }
		[Column] public int? Pin { get; set; }
		[Column] public string State { get; set; }
		[Column] public string Country { get; set; }
		[Column] public string NameOn { get; set; }
		[Column] public int? Star { get; set; }
		[Column] public string Occassion { get; set; }
		[Column] public string Gothram { get; set; }
		[Column] public int Amount { get; set; }
		[Column] public int MR_No { get; set; }
		[Column] public string Remarks { get; set; }
		[Column] public string PhoneNumber { get; set; }
		[Column] public int? SpecialDayId { get; set; }
		[Column] public int? ServiceTypeId { get; set; }
		[Column] public int? ServiceNameId { get; set; }
		[Column] public int? DateTypeId { get; set; }
		[Column] public DateTime? PerformDate { get; set; }
		[Column] public string EmailId { get; set; }
		[Column] public string Paksha { get; set; }
		[Column] public int? Month { get; set; }
		[Column] public int? Thidhi { get; set; }
		[Column] public int? Day { get; set; }
	}
    
	[TableName("employees")]
	[PrimaryKey("Id", autoIncrement=false)]
	[ExplicitColumns]
    public partial class employee : eTempleDbDB.Record<employee>  
    {
		[Column] public int Id { get; set; }
		[Column] public string Name { get; set; }
		[Column] public int Role { get; set; }
		[Column] public string LoginId { get; set; }
		[Column] public string Password { get; set; }
		[Column] public int? CreatedBy { get; set; }
		[Column] public DateTime? CreatedOn { get; set; }
		[Column] public int? ModifiedBy { get; set; }
		[Column] public DateTime? ModifiedOn { get; set; }
	}
    
	[TableName("gothrams")]
	[PrimaryKey("Id")]
	[ExplicitColumns]
    public partial class gothram : eTempleDbDB.Record<gothram>  
    {
		[Column] public int Id { get; set; }
		[Column] public string Name { get; set; }
	}
    
	[TableName("month")]
	[PrimaryKey("Id")]
	[ExplicitColumns]
    public partial class month : eTempleDbDB.Record<month>  
    {
		[Column] public int Id { get; set; }
		[Column] public string Name { get; set; }
	}
    
	[TableName("monthlyannadanamtbl")]
	[PrimaryKey("Id", autoIncrement=false)]
	[ExplicitColumns]
    public partial class monthlyannadanamtbl : eTempleDbDB.Record<monthlyannadanamtbl>  
    {
		[Column] public int Id { get; set; }
		[Column] public string Day { get; set; }
	}
    
	[TableName("paksha")]
	[PrimaryKey("Id", autoIncrement=false)]
	[ExplicitColumns]
    public partial class paksha : eTempleDbDB.Record<paksha>  
    {
		[Column] public int Id { get; set; }
		[Column] public string Name { get; set; }
	}
    
	[TableName("prefixes")]
	[PrimaryKey("Id")]
	[ExplicitColumns]
    public partial class prefix : eTempleDbDB.Record<prefix>  
    {
		[Column] public int Id { get; set; }
		[Column] public string Name { get; set; }
	}
    
	[TableName("role_module_mapping")]
	[ExplicitColumns]
    public partial class role_module_mapping : eTempleDbDB.Record<role_module_mapping>  
    {
	}
    
	[TableName("roles")]
	[PrimaryKey("Id")]
	[ExplicitColumns]
    public partial class role : eTempleDbDB.Record<role>  
    {
		[Column] public int Id { get; set; }
		[Column] public string Name { get; set; }
	}
    
	[TableName("servicename")]
	[PrimaryKey("Id", autoIncrement=false)]
	[ExplicitColumns]
    public partial class servicename : eTempleDbDB.Record<servicename>  
    {
		[Column] public int Id { get; set; }
		[Column] public string Name { get; set; }
		[Column] public int ServiceTypeId { get; set; }
		[Column] public int IsDateRelated { get; set; }
		[Column] public int? OrderId { get; set; }
	}
    
	[TableName("servicetypes")]
	[PrimaryKey("Id", autoIncrement=false)]
	[ExplicitColumns]
    public partial class servicetype : eTempleDbDB.Record<servicetype>  
    {
		[Column] public int Id { get; set; }
		[Column] public string Name { get; set; }
		[Column] public int IsDateRelated { get; set; }
		[Column] public int? Cost { get; set; }
		[Column] public DateTime? CreatedOn { get; set; }
		[Column] public int? CreatedBy { get; set; }
		[Column] public int? ModifiedBy { get; set; }
		[Column] public DateTime? ModifiedOn { get; set; }
	}
    
	[TableName("specialday")]
	[PrimaryKey("Id", autoIncrement=false)]
	[ExplicitColumns]
    public partial class specialday : eTempleDbDB.Record<specialday>  
    {
		[Column] public int Id { get; set; }
		[Column] public string Name { get; set; }
	}
    
	[TableName("stars")]
	[PrimaryKey("Id", autoIncrement=false)]
	[ExplicitColumns]
    public partial class star : eTempleDbDB.Record<star>  
    {
		[Column] public int Id { get; set; }
		[Column] public string Name { get; set; }
	}
    
	[TableName("state")]
	[PrimaryKey("Id", autoIncrement=false)]
	[ExplicitColumns]
    public partial class state : eTempleDbDB.Record<state>  
    {
		[Column] public int Id { get; set; }
		[Column] public string Name { get; set; }
	}
    
	[TableName("telugucalendar")]
	[PrimaryKey("EnglishDate", autoIncrement=false)]
	[ExplicitColumns]
    public partial class telugucalendar : eTempleDbDB.Record<telugucalendar>  
    {
		[Column] public DateTime EnglishDate { get; set; }
		[Column] public int Masam { get; set; }
		[Column] public int Thidhi { get; set; }
	}
    
	[TableName("thidhi")]
	[PrimaryKey("Id", autoIncrement=false)]
	[ExplicitColumns]
    public partial class thidhi : eTempleDbDB.Record<thidhi>  
    {
		[Column] public int Id { get; set; }
		[Column] public string Name { get; set; }
	}
    
	[TableName("transactiontype")]
	[PrimaryKey("Id", autoIncrement=false)]
	[ExplicitColumns]
    public partial class transactiontype : eTempleDbDB.Record<transactiontype>  
    {
		[Column] public int Id { get; set; }
		[Column] public string Name { get; set; }
	}
    
	[TableName("columns_priv")]
	[ExplicitColumns]
    public partial class columns_priv : eTempleDbDB.Record<columns_priv>  
    {
	}
    
	[TableName("db")]
	[ExplicitColumns]
    public partial class db : eTempleDbDB.Record<db>  
    {
	}
    
	[TableName("event")]
	[ExplicitColumns]
    public partial class @event : eTempleDbDB.Record<@event>  
    {
	}
    
	[TableName("func")]
	[ExplicitColumns]
    public partial class func : eTempleDbDB.Record<func>  
    {
	}
    
	[TableName("general_log")]
	[ExplicitColumns]
    public partial class general_log : eTempleDbDB.Record<general_log>  
    {
	}
    
	[TableName("help_category")]
	[ExplicitColumns]
    public partial class help_category : eTempleDbDB.Record<help_category>  
    {
	}
    
	[TableName("help_keyword")]
	[ExplicitColumns]
    public partial class help_keyword : eTempleDbDB.Record<help_keyword>  
    {
	}
    
	[TableName("help_relation")]
	[ExplicitColumns]
    public partial class help_relation : eTempleDbDB.Record<help_relation>  
    {
	}
    
	[TableName("help_topic")]
	[ExplicitColumns]
    public partial class help_topic : eTempleDbDB.Record<help_topic>  
    {
	}
    
	[TableName("innodb_index_stats")]
	[ExplicitColumns]
    public partial class innodb_index_stat : eTempleDbDB.Record<innodb_index_stat>  
    {
	}
    
	[TableName("innodb_table_stats")]
	[ExplicitColumns]
    public partial class innodb_table_stat : eTempleDbDB.Record<innodb_table_stat>  
    {
	}
    
	[TableName("ndb_binlog_index")]
	[ExplicitColumns]
    public partial class ndb_binlog_index : eTempleDbDB.Record<ndb_binlog_index>  
    {
	}
    
	[TableName("plugin")]
	[ExplicitColumns]
    public partial class plugin : eTempleDbDB.Record<plugin>  
    {
	}
    
	[TableName("proc")]
	[ExplicitColumns]
    public partial class proc : eTempleDbDB.Record<proc>  
    {
	}
    
	[TableName("procs_priv")]
	[ExplicitColumns]
    public partial class procs_priv : eTempleDbDB.Record<procs_priv>  
    {
	}
    
	[TableName("proxies_priv")]
	[ExplicitColumns]
    public partial class proxies_priv : eTempleDbDB.Record<proxies_priv>  
    {
	}
    
	[TableName("servers")]
	[ExplicitColumns]
    public partial class server : eTempleDbDB.Record<server>  
    {
	}
    
	[TableName("slave_master_info")]
	[ExplicitColumns]
    public partial class slave_master_info : eTempleDbDB.Record<slave_master_info>  
    {
	}
    
	[TableName("slave_relay_log_info")]
	[ExplicitColumns]
    public partial class slave_relay_log_info : eTempleDbDB.Record<slave_relay_log_info>  
    {
	}
    
	[TableName("slave_worker_info")]
	[ExplicitColumns]
    public partial class slave_worker_info : eTempleDbDB.Record<slave_worker_info>  
    {
	}
    
	[TableName("slow_log")]
	[ExplicitColumns]
    public partial class slow_log : eTempleDbDB.Record<slow_log>  
    {
	}
    
	[TableName("tables_priv")]
	[ExplicitColumns]
    public partial class tables_priv : eTempleDbDB.Record<tables_priv>  
    {
	}
    
	[TableName("time_zone")]
	[ExplicitColumns]
    public partial class time_zone : eTempleDbDB.Record<time_zone>  
    {
	}
    
	[TableName("time_zone_leap_second")]
	[ExplicitColumns]
    public partial class time_zone_leap_second : eTempleDbDB.Record<time_zone_leap_second>  
    {
	}
    
	[TableName("time_zone_name")]
	[ExplicitColumns]
    public partial class time_zone_name : eTempleDbDB.Record<time_zone_name>  
    {
	}
    
	[TableName("time_zone_transition")]
	[ExplicitColumns]
    public partial class time_zone_transition : eTempleDbDB.Record<time_zone_transition>  
    {
	}
    
	[TableName("time_zone_transition_type")]
	[ExplicitColumns]
    public partial class time_zone_transition_type : eTempleDbDB.Record<time_zone_transition_type>  
    {
	}
    
	[TableName("user")]
	[ExplicitColumns]
    public partial class user : eTempleDbDB.Record<user>  
    {
	}
    
	[TableName("accounts")]
	[ExplicitColumns]
    public partial class account : eTempleDbDB.Record<account>  
    {
	}
    
	[TableName("cond_instances")]
	[ExplicitColumns]
    public partial class cond_instance : eTempleDbDB.Record<cond_instance>  
    {
	}
    
	[TableName("events_stages_current")]
	[ExplicitColumns]
    public partial class events_stages_current : eTempleDbDB.Record<events_stages_current>  
    {
	}
    
	[TableName("events_stages_history")]
	[ExplicitColumns]
    public partial class events_stages_history : eTempleDbDB.Record<events_stages_history>  
    {
	}
    
	[TableName("events_stages_history_long")]
	[ExplicitColumns]
    public partial class events_stages_history_long : eTempleDbDB.Record<events_stages_history_long>  
    {
	}
    
	[TableName("events_stages_summary_by_account_by_event_name")]
	[ExplicitColumns]
    public partial class events_stages_summary_by_account_by_event_name : eTempleDbDB.Record<events_stages_summary_by_account_by_event_name>  
    {
	}
    
	[TableName("events_stages_summary_by_host_by_event_name")]
	[ExplicitColumns]
    public partial class events_stages_summary_by_host_by_event_name : eTempleDbDB.Record<events_stages_summary_by_host_by_event_name>  
    {
	}
    
	[TableName("events_stages_summary_by_thread_by_event_name")]
	[ExplicitColumns]
    public partial class events_stages_summary_by_thread_by_event_name : eTempleDbDB.Record<events_stages_summary_by_thread_by_event_name>  
    {
	}
    
	[TableName("events_stages_summary_by_user_by_event_name")]
	[ExplicitColumns]
    public partial class events_stages_summary_by_user_by_event_name : eTempleDbDB.Record<events_stages_summary_by_user_by_event_name>  
    {
	}
    
	[TableName("events_stages_summary_global_by_event_name")]
	[ExplicitColumns]
    public partial class events_stages_summary_global_by_event_name : eTempleDbDB.Record<events_stages_summary_global_by_event_name>  
    {
	}
    
	[TableName("events_statements_current")]
	[ExplicitColumns]
    public partial class events_statements_current : eTempleDbDB.Record<events_statements_current>  
    {
	}
    
	[TableName("events_statements_history")]
	[ExplicitColumns]
    public partial class events_statements_history : eTempleDbDB.Record<events_statements_history>  
    {
	}
    
	[TableName("events_statements_history_long")]
	[ExplicitColumns]
    public partial class events_statements_history_long : eTempleDbDB.Record<events_statements_history_long>  
    {
	}
    
	[TableName("events_statements_summary_by_account_by_event_name")]
	[ExplicitColumns]
    public partial class events_statements_summary_by_account_by_event_name : eTempleDbDB.Record<events_statements_summary_by_account_by_event_name>  
    {
	}
    
	[TableName("events_statements_summary_by_digest")]
	[ExplicitColumns]
    public partial class events_statements_summary_by_digest : eTempleDbDB.Record<events_statements_summary_by_digest>  
    {
	}
    
	[TableName("events_statements_summary_by_host_by_event_name")]
	[ExplicitColumns]
    public partial class events_statements_summary_by_host_by_event_name : eTempleDbDB.Record<events_statements_summary_by_host_by_event_name>  
    {
	}
    
	[TableName("events_statements_summary_by_thread_by_event_name")]
	[ExplicitColumns]
    public partial class events_statements_summary_by_thread_by_event_name : eTempleDbDB.Record<events_statements_summary_by_thread_by_event_name>  
    {
	}
    
	[TableName("events_statements_summary_by_user_by_event_name")]
	[ExplicitColumns]
    public partial class events_statements_summary_by_user_by_event_name : eTempleDbDB.Record<events_statements_summary_by_user_by_event_name>  
    {
	}
    
	[TableName("events_statements_summary_global_by_event_name")]
	[ExplicitColumns]
    public partial class events_statements_summary_global_by_event_name : eTempleDbDB.Record<events_statements_summary_global_by_event_name>  
    {
	}
    
	[TableName("events_waits_current")]
	[ExplicitColumns]
    public partial class events_waits_current : eTempleDbDB.Record<events_waits_current>  
    {
	}
    
	[TableName("events_waits_history")]
	[ExplicitColumns]
    public partial class events_waits_history : eTempleDbDB.Record<events_waits_history>  
    {
	}
    
	[TableName("events_waits_history_long")]
	[ExplicitColumns]
    public partial class events_waits_history_long : eTempleDbDB.Record<events_waits_history_long>  
    {
	}
    
	[TableName("events_waits_summary_by_account_by_event_name")]
	[ExplicitColumns]
    public partial class events_waits_summary_by_account_by_event_name : eTempleDbDB.Record<events_waits_summary_by_account_by_event_name>  
    {
	}
    
	[TableName("events_waits_summary_by_host_by_event_name")]
	[ExplicitColumns]
    public partial class events_waits_summary_by_host_by_event_name : eTempleDbDB.Record<events_waits_summary_by_host_by_event_name>  
    {
	}
    
	[TableName("events_waits_summary_by_instance")]
	[ExplicitColumns]
    public partial class events_waits_summary_by_instance : eTempleDbDB.Record<events_waits_summary_by_instance>  
    {
	}
    
	[TableName("events_waits_summary_by_thread_by_event_name")]
	[ExplicitColumns]
    public partial class events_waits_summary_by_thread_by_event_name : eTempleDbDB.Record<events_waits_summary_by_thread_by_event_name>  
    {
	}
    
	[TableName("events_waits_summary_by_user_by_event_name")]
	[ExplicitColumns]
    public partial class events_waits_summary_by_user_by_event_name : eTempleDbDB.Record<events_waits_summary_by_user_by_event_name>  
    {
	}
    
	[TableName("events_waits_summary_global_by_event_name")]
	[ExplicitColumns]
    public partial class events_waits_summary_global_by_event_name : eTempleDbDB.Record<events_waits_summary_global_by_event_name>  
    {
	}
    
	[TableName("file_instances")]
	[ExplicitColumns]
    public partial class file_instance : eTempleDbDB.Record<file_instance>  
    {
	}
    
	[TableName("file_summary_by_event_name")]
	[ExplicitColumns]
    public partial class file_summary_by_event_name : eTempleDbDB.Record<file_summary_by_event_name>  
    {
	}
    
	[TableName("file_summary_by_instance")]
	[ExplicitColumns]
    public partial class file_summary_by_instance : eTempleDbDB.Record<file_summary_by_instance>  
    {
	}
    
	[TableName("host_cache")]
	[ExplicitColumns]
    public partial class host_cache : eTempleDbDB.Record<host_cache>  
    {
	}
    
	[TableName("hosts")]
	[ExplicitColumns]
    public partial class host : eTempleDbDB.Record<host>  
    {
	}
    
	[TableName("mutex_instances")]
	[ExplicitColumns]
    public partial class mutex_instance : eTempleDbDB.Record<mutex_instance>  
    {
	}
    
	[TableName("objects_summary_global_by_type")]
	[ExplicitColumns]
    public partial class objects_summary_global_by_type : eTempleDbDB.Record<objects_summary_global_by_type>  
    {
	}
    
	[TableName("performance_timers")]
	[ExplicitColumns]
    public partial class performance_timer : eTempleDbDB.Record<performance_timer>  
    {
	}
    
	[TableName("rwlock_instances")]
	[ExplicitColumns]
    public partial class rwlock_instance : eTempleDbDB.Record<rwlock_instance>  
    {
	}
    
	[TableName("session_account_connect_attrs")]
	[ExplicitColumns]
    public partial class session_account_connect_attr : eTempleDbDB.Record<session_account_connect_attr>  
    {
	}
    
	[TableName("session_connect_attrs")]
	[ExplicitColumns]
    public partial class session_connect_attr : eTempleDbDB.Record<session_connect_attr>  
    {
	}
    
	[TableName("setup_actors")]
	[ExplicitColumns]
    public partial class setup_actor : eTempleDbDB.Record<setup_actor>  
    {
	}
    
	[TableName("setup_consumers")]
	[ExplicitColumns]
    public partial class setup_consumer : eTempleDbDB.Record<setup_consumer>  
    {
	}
    
	[TableName("setup_instruments")]
	[ExplicitColumns]
    public partial class setup_instrument : eTempleDbDB.Record<setup_instrument>  
    {
	}
    
	[TableName("setup_objects")]
	[ExplicitColumns]
    public partial class setup_object : eTempleDbDB.Record<setup_object>  
    {
	}
    
	[TableName("setup_timers")]
	[ExplicitColumns]
    public partial class setup_timer : eTempleDbDB.Record<setup_timer>  
    {
	}
    
	[TableName("socket_instances")]
	[ExplicitColumns]
    public partial class socket_instance : eTempleDbDB.Record<socket_instance>  
    {
	}
    
	[TableName("socket_summary_by_event_name")]
	[ExplicitColumns]
    public partial class socket_summary_by_event_name : eTempleDbDB.Record<socket_summary_by_event_name>  
    {
	}
    
	[TableName("socket_summary_by_instance")]
	[ExplicitColumns]
    public partial class socket_summary_by_instance : eTempleDbDB.Record<socket_summary_by_instance>  
    {
	}
    
	[TableName("table_io_waits_summary_by_index_usage")]
	[ExplicitColumns]
    public partial class table_io_waits_summary_by_index_usage : eTempleDbDB.Record<table_io_waits_summary_by_index_usage>  
    {
	}
    
	[TableName("table_io_waits_summary_by_table")]
	[ExplicitColumns]
    public partial class table_io_waits_summary_by_table : eTempleDbDB.Record<table_io_waits_summary_by_table>  
    {
	}
    
	[TableName("table_lock_waits_summary_by_table")]
	[ExplicitColumns]
    public partial class table_lock_waits_summary_by_table : eTempleDbDB.Record<table_lock_waits_summary_by_table>  
    {
	}
    
	[TableName("threads")]
	[ExplicitColumns]
    public partial class thread : eTempleDbDB.Record<thread>  
    {
	}
   
	[TableName("actor")]
	[ExplicitColumns]
    public partial class actor : eTempleDbDB.Record<actor>  
    {
	}
    
	[TableName("address")]
	[ExplicitColumns]
    public partial class address : eTempleDbDB.Record<address>  
    {
	}
    
	[TableName("category")]
	[ExplicitColumns]
    public partial class category : eTempleDbDB.Record<category>  
    {
	}
    
	[TableName("city")]
	[ExplicitColumns]
    public partial class city : eTempleDbDB.Record<city>  
    {
	}
    
	[TableName("country")]
	[ExplicitColumns]
    public partial class country : eTempleDbDB.Record<country>  
    {
	}
    
	[TableName("customer")]
	[ExplicitColumns]
    public partial class customer : eTempleDbDB.Record<customer>  
    {
	}
    
	[TableName("film")]
	[ExplicitColumns]
    public partial class film : eTempleDbDB.Record<film>  
    {
	}
    
	[TableName("film_actor")]
	[ExplicitColumns]
    public partial class film_actor : eTempleDbDB.Record<film_actor>  
    {
	}
    
	[TableName("film_category")]
	[ExplicitColumns]
    public partial class film_category : eTempleDbDB.Record<film_category>  
    {
	}
    
	[TableName("film_text")]
	[ExplicitColumns]
    public partial class film_text : eTempleDbDB.Record<film_text>  
    {
	}
    
	[TableName("inventory")]
	[ExplicitColumns]
    public partial class inventory : eTempleDbDB.Record<inventory>  
    {
	}
    
	[TableName("language")]
	[ExplicitColumns]
    public partial class language : eTempleDbDB.Record<language>  
    {
	}
    
	[TableName("payment")]
	[ExplicitColumns]
    public partial class payment : eTempleDbDB.Record<payment>  
    {
	}
    
	[TableName("rental")]
	[ExplicitColumns]
    public partial class rental : eTempleDbDB.Record<rental>  
    {
	}
    
	[TableName("staff")]
	[ExplicitColumns]
    public partial class staff : eTempleDbDB.Record<staff>  
    {
	}
    
	[TableName("store")]
	[ExplicitColumns]
    public partial class store : eTempleDbDB.Record<store>  
    {
	}
    
	[TableName("countrylanguage")]
	[ExplicitColumns]
    public partial class countrylanguage : eTempleDbDB.Record<countrylanguage>  
    {
	}
}



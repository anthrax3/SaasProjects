using System;
using System.Data.Common;
namespace NnerSoft.Bas.DBUtility
{
	public class CommandInfo
	{
		public object ShareObject = null;
		public object OriginalData = null;
		public string CommandText;
		public DbParameter[] Parameters;
		public EffentNextType EffentNextType = EffentNextType.None;
		private event System.EventHandler _solicitationEvent;
		public event System.EventHandler SolicitationEvent
		{
			add
			{
				this._solicitationEvent += value;
			}
			remove
			{
				this._solicitationEvent -= value;
			}
		}
		public void OnSolicitationEvent()
		{
			if (this._solicitationEvent != null)
			{
				this._solicitationEvent(this, new System.EventArgs());
			}
		}
		public CommandInfo()
		{
		}
		public CommandInfo(string sqlText, DbParameter[] para)
		{
			this.CommandText = sqlText;
			this.Parameters = para;
		}
		public CommandInfo(string sqlText, DbParameter[] para, EffentNextType type)
		{
			this.CommandText = sqlText;
			this.Parameters = para;
			this.EffentNextType = type;
		}
	}
}

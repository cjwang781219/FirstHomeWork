using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;

namespace FirstHomeWork.Models
{   
	public  class 客戶銀行資訊Repository : EFRepository<客戶銀行資訊>, I客戶銀行資訊Repository
	{
        public List<客戶銀行資訊> get客戶銀行資料()
        {
            return this.All().Where(x=>x.是否已刪除==true).ToList();
        }
        public 客戶銀行資訊 get客戶銀行資料ByID(int id)
        {
            return this.All().FirstOrDefault(p => p.Id == id);
        }

        public void Edit(客戶銀行資訊 customBank)
        {
            this.UnitOfWork.Context.Entry(customBank).State = EntityState.Modified;
        }
    }

	public  interface I客戶銀行資訊Repository : IRepository<客戶銀行資訊>
	{

	}
}
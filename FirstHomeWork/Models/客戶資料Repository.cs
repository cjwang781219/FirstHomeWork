using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;

namespace FirstHomeWork.Models
{   
	public  class 客戶資料Repository : EFRepository<客戶資料>, I客戶資料Repository
	{
        public List<客戶資料> get客戶資料()
        {
            return this.All().Where(x => x.是否已刪除 == true).ToList();
        }
        public 客戶資料 get客戶資料ByID(int id)
        {
            return this.All().FirstOrDefault(p => p.Id == id);
        }

        public void Edit(客戶資料 customBank)
        {
            this.UnitOfWork.Context.Entry(customBank).State = EntityState.Modified;
        }
    }

	public  interface I客戶資料Repository : IRepository<客戶資料>
	{

	}
}
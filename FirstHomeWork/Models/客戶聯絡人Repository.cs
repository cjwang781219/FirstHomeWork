using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;

namespace FirstHomeWork.Models
{   
	public  class 客戶聯絡人Repository : EFRepository<客戶聯絡人>, I客戶聯絡人Repository
	{
        public List<客戶聯絡人> get客戶聯絡人()
        {
            return this.All().Where(x => x.是否已刪除 == true).ToList();
        }
        public 客戶聯絡人 get客戶聯絡人ByID(int id)
        {
            return this.All().FirstOrDefault(p => p.Id == id);
        }

        public void Edit(客戶聯絡人 customBank)
        {
            this.UnitOfWork.Context.Entry(customBank).State = EntityState.Modified;
        }
    }

	public  interface I客戶聯絡人Repository : IRepository<客戶聯絡人>
	{

	}
}
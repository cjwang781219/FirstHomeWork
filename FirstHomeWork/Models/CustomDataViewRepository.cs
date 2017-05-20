using System;
using System.Linq;
using System.Collections.Generic;
	
namespace FirstHomeWork.Models
{   
	public  class CustomDataViewRepository : EFRepository<CustomDataView>, ICustomDataViewRepository
	{

	}

	public  interface ICustomDataViewRepository : IRepository<CustomDataView>
	{

	}
}
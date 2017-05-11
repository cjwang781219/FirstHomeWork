using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FirstHomeWork.Models.PartialModels
{
    [MetadataType(typeof(CustomDataViewMetaData))]
    public partial class CustomDataView
    {

    }
    public class CustomDataViewMetaData
    {
        public int Id { get; set; }
        public string 客戶名稱 { get; set; }
        public Nullable<int> 銀行數量 { get; set; }
        public Nullable<int> 聯絡人數量 { get; set; }
    }
}
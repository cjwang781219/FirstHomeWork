namespace FirstHomeWork.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(CustomDataViewMetaData))]
    public partial class CustomDataView
    {
    }
    
    public partial class CustomDataViewMetaData
    {
        [Required]
        public int Id { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string 客戶名稱 { get; set; }
        public Nullable<int> 銀行數量 { get; set; }
        public Nullable<int> 聯絡人數量 { get; set; }
    }
}

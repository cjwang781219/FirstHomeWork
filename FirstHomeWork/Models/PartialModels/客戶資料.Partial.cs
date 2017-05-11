using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FirstHomeWork.Models
{
    [MetadataType(typeof(客戶資料MetaData))]
    public partial class 客戶資料{}
    public class 客戶資料MetaData
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50,ErrorMessage ="不可超過50個字")]
        public string 客戶名稱 { get; set; }

        [Required]
        [MaxLength(8,ErrorMessage ="統編長度為8碼")]
        public string 統一編號 { get; set; }

        [Required]
        public string 電話 { get; set; }
        public string 傳真 { get; set; }
        public string 地址 { get; set; }

        [RegularExpression(@"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",ErrorMessage ="Email格式錯誤")]
        public string Email { get; set; }
        public bool 是否已刪除 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<客戶銀行資訊> 客戶銀行資訊 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<客戶聯絡人> 客戶聯絡人 { get; set; }
    }
}
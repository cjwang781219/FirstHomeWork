using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace FirstHomeWork.Models
{
    [MetadataType(typeof(客戶聯絡人MetaData))]
    public partial class 客戶聯絡人 : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            Regex reg = new Regex("\\d{4}-\\d{6}");
            if (this.手機 != null && !reg.IsMatch(this.手機))
            {
                yield return new ValidationResult("手機格式錯誤", new string[] { "手機" });
            }

            客戶資料Entities db = new 客戶資料Entities();

            int count = db.客戶聯絡人.Where(x => x.是否已刪除 == false && x.客戶Id == this.客戶Id && x.Email == this.Email).Count();
            if (count > 0)
            {
                yield return new ValidationResult("Email已存在", new string[] { "Email" });
            }

            yield break;
        }
    }
    public class 客戶聯絡人MetaData
    {
        public int Id { get; set; }

        [Required]
        public int 客戶Id { get; set; }

        [Required]
        public string 職稱 { get; set; }

        [Required]
        public string 姓名 { get; set; }

        [Required]
        [RegularExpression(@"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$", ErrorMessage = "Email格式錯誤")]
        public string Email { get; set; }


        public string 手機 { get; set; }


        public string 電話 { get; set; }


        public bool 是否已刪除 { get; set; }

        public virtual 客戶資料 客戶資料 { get; set; }
    }
}
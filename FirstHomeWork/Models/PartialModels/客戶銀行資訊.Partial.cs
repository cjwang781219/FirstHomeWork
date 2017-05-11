﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FirstHomeWork.Models
{
    [MetadataType(typeof(客戶銀行資訊MetaData))]
    public partial class 客戶銀行資訊 { }

    public class 客戶銀行資訊MetaData
	{
        public int Id { get; set; }

		[Required(ErrorMessage ="客戶ID為必選")]
        public int 客戶Id { get; set; }

		[Required]
		[MaxLength(50,ErrorMessage ="長度不可大於50")]
        public string 銀行名稱 { get; set; }

        [Required]
        public int 銀行代碼 { get; set; }


        public Nullable<int> 分行代碼 { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "長度不可大於50")]
        public string 帳戶名稱 { get; set; }

        [Required]
		[MaxLength(20,ErrorMessage ="長度不可大於20")]
        public string 帳戶號碼 { get; set; }


        public bool 是否已刪除 { get; set; }

        public virtual 客戶資料 客戶資料 { get; set; }
    }
}
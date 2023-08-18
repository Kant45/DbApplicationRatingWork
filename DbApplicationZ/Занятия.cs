using System;
using System.Collections.Generic;

#nullable disable

namespace DbApplicationZ
{
    public partial class Занятия
    {
        public int ЗанятияId { get; set; }
        public string Дисциплина { get; set; }
        public DateTime? ДатаЗанятия { get; set; }
        public string Группа { get; set; }
        public int? ЧасоваяСтавка { get; set; }
        public int? КолВоЧас { get; set; }
        public string ТабельныйНомер { get; set; }

        public virtual Преподаватели ТабельныйНомерNavigation { get; set; }
    }
}

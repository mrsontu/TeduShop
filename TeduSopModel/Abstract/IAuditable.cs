using System;
using System.Collections.Generic;
using System.Text;

namespace TeduSopModel.Abstract
{
    public interface IAuditable
    {
        DateTime CreatedDate { get; set; }
        string CreatedBy { get; set; }
        DateTime? UpdateDate { get; set; }
        string UpdateBy { get; set; }
        bool Status { get; set; }
        string MetaKeyword { get; set; }
        string MetaDescription { get; set; }

    }
}

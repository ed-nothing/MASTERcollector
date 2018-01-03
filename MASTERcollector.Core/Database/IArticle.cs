using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASTERcollector.Database
{
    public interface IArticle
    {
        int ArticleId { get; }
        Guid Collector { get; }
        string Title { get; set; }
        string Identity { get; set; }
        string Tags { get; set; }
        DateTime PublishDate { get; set; }
        DateTime CollectDate { get; }
        string PlainContent { get; set; }
        string RawContent { get; set; }
        string ExternalData { get; set; }
        string RefUrl { get; set; }
    }
}

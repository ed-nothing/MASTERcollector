using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASTERcollector.Database
{
    public interface IIsolatedStorage
    {
        IArticle this[int index] { get; }

        void AppendArticle(IArticle article);
        void UpdateAritcle(IArticle article);
        void RemoveArticle(IArticle article);

    }
}

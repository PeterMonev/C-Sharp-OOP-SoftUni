using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite.Models.Interfaces
{
    public interface IGiftOperations
    {
        void Remove(GiftBase gift);
        void Add(GiftBase gift);
    }
}

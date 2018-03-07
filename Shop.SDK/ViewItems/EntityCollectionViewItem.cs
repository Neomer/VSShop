using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Shop.SDK.Models;

namespace Shop.SDK.ViewItems
{
    public class EntityCollectionViewItem : IEntityCollectionViewItem
    {
        public IEnumerator<IEntity> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
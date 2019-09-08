using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETC.Data;
using System.Windows.Forms;

namespace ETC
{
    public class DataPresenter
    {
        List<Catalog_level> level;
        List<Catalog_level> GetLevelData()
        {
            try
            {
                using (var context = new SparesContext())
                {
                    level = (from c in context.Catalog_levels
                             select c).ToList();
                }
                return level;
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public void FillData(TreeView trVBase)
        {
            List<Catalog_level> data = GetLevelData();
            List<Catalog_level> zeroLevel = (from d in data
                                             where d.Parent_id == 0
                                             select d).ToList();
            int i = 0;
            foreach (var zl in zeroLevel)
            {
                trVBase.Nodes.Add(new TreeNode(zl.Name));
                List<Catalog_level> firstParent = (from d in data
                                                   where d.Parent_id == zl.Id
                                                   select d).ToList();
                int j = 0;
                foreach (var child in firstParent)
                {
                    
                    trVBase.Nodes[i].Nodes.Add(child.Name);
                    List<string> secondParent = (from d in data
                                                where d.Parent_id == child.Id
                                                select d.Name).ToList();
                    foreach (var second in secondParent)
                    {
                        trVBase.Nodes[i].Nodes[j].Nodes.Add(second);
                    }
                    j++;
                }
                i++;
            }
        }


    }
}

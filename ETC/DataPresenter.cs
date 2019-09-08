using System.Collections.Generic;
using System.Linq;
using ETC.Data;
using System.Windows.Forms;
using System.Threading.Tasks;
using System;

namespace ETC
{
    public class DataPresenter
    {
        DataFunction dt = new DataFunction();
        public DataPresenter()
        {
            dt.GetLevelData();
        }

        public TreeNode[] FillData()
        {
            List<Catalog_level> zeroLevel = (from d in dt.level
                                             where d.Parent_id == 0
                                             select d).ToList();
            TreeNode[] trn = new TreeNode[zeroLevel.Count];
            int i = 0;
            foreach (var zl in zeroLevel)
            {
                trn[i] = new TreeNode(zl.Name);
                List<Catalog_level> firstParent = (from d in dt.level
                                                   where d.Parent_id == zl.Id
                                                   select d).ToList();
                int j = 0;
                foreach (var child in firstParent)
                {

                    trn[i].Nodes.Add(child.Name);
                    List<string> secondParent = (from d in dt.level
                                                 where d.Parent_id == child.Id
                                                select d.Name).ToList();
                    foreach (var second in secondParent)
                    {
                        trn[i].Nodes[j].Nodes.Add(second);
                    }
                    j++;
                }
                i++;
            }
            GC.Collect();
            return trn;
        }


    }
}

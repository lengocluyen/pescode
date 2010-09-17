using System;
using System.Collections.Generic;
using System.Linq;
using SubSonic.Extensions;

namespace Pes.Core
{
    public partial class VModule
    {
      
        //Chu y khi viet kieu nay: Dung SingleOrDefault thay vi Single,
        //nham tra ve null khi k tim thay,
        //neu k thi se fat sinh loi "Sequence contains no elements"
        //static Func<ITBusDataContext, int, Module>
        //    GetModuleByID_Fun = CompiledQuery.Compile
        //    ((ITBusDataContext context, int id) => context.Modules.Where
        //        (module => module.ModuleId == id).SingleOrDefault<Module>());

        public static VModule GetModuleByID(int id)
        {
            return VModule.Single(id);
        }

        public static List<VModule> GetListModules()
        {
            return All().ToList();
        }

        public static void InsertModule(VModule Module)
        {
            Add(Module);
        }

        public static void DeleteModule(VModule moBO)
        {
            Delete(moBO);
        }

        public static void UpdateModule(VModule moBO)
        {
            Update(moBO);
        }

        public static List<VModule> GetFrTo(IQueryable<VModule> table, int start, int end)
        {
            if (start <= 0)
                start = 1;
            List<VModule> list = table.Skip(start - 1).Take(end - start + 1).ToList();

            return list;
        }

        public static int CountAllModule()
        {
            return All().Count();
        }

        public static List<VModule> GetItemFromTo(int start, int end)
        {
            return GetFrTo(All(), start, end);
        }
    }
}
using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Grasshopper.Kernel.Types;
using Rhino.Geometry;

namespace nsGH2
{
    public class comp3 : GH_Component
    {
        private bool m_absolute = false;
        public bool Absolute
        {
            get { return m_absolute; }
            set { m_absolute = value;
                if ((m_absolute))
                {
                    Message = "Absolute";
                }
                else
                {
                    Message = "Standard";
                }
            }
        }
        public comp3()
          : base("comp3", "Nickname",
              "Description",
              "dmX", "test-3")
        {
        }
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddNumberParameter("Values", "V", "Values to sort", GH_ParamAccess.list);
        }
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddNumberParameter("Values", "V", "Sorted Values", GH_ParamAccess.list);
        }
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            List<double> values = new List<double>();
            if ((!DA.GetDataList(0, values)))
                return;
            if ((values.Count == 0))
                return;

            if ((Absolute))
            {
                for (Int32 i = 0; i < values.Count; i++)
                {
                    values[i] = Math.Abs(values[i]);
                }
            }

            values.Sort();
            DA.SetDataList(0, values);
        }
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return null;
            }
        }
        public override Guid ComponentGuid
        {
            get { return new Guid("ff2ea506-1e1a-4f47-8dd3-e524d25aee69"); }
        }
    }


}
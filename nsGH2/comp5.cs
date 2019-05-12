using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Grasshopper.Kernel.Types;
using Rhino.Geometry;

namespace nsGH2
{
    public class comp5 : Grasshopper.Kernel.GH_Component
    {
        public comp5()
          : base("comp5", "c5",
              "many-to-many io",
              "dmX", "geom-test")
        {
        }

        public override Grasshopper.Kernel.GH_Exposure Exposure
        {
            get { return GH_Exposure.primary | GH_Exposure.obscure; }
        }

        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGeometryParameter("Geometry", "g", "Geometry input", GH_ParamAccess.list);
            pManager.AddIntegerParameter("Count", "c", "number to remove", GH_ParamAccess.item);
        }
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGeometryParameter("Geometry", "g", "culled geometry", GH_ParamAccess.list);
        }
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            List<IGH_GeometricGoo> geometry = new List<IGH_GeometricGoo>();
            Int32 count = 0;
            if (!DA.GetDataList(0, geometry)) return;
            if (!DA.GetData(1, ref count)) return;

            if (count < 0)
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Error, "Count < 0");
                return;
            }
            if (geometry.Count < 0)
            {
                return;
            }
            for (int i = 0; i < geometry.Count; i++)
            {
                Rhino.Geometry.Vector3d vec = new Rhino.Geometry.Vector3d(0, 0, 10);
                var xf = Rhino.Geometry.Transform.Translation(vec);
                geometry[i].Transform(Rhino.Geometry.Transform.Translation(vec));
            }
            DA.SetDataList(0, geometry);
        }
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return new System.Drawing.Bitmap("C:/Users/Nirvik Saha/Documents/Visual Studio 2017/Projects/nsGH2/nsGH2/bin/icon.png");
            }
        }
        public override Guid ComponentGuid
        {
            get { return new Guid("95657622-b990-4796-a395-dc607b588504"); }
        }
    }
}
using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace nsGH2
{
    public class comp4 : GH_Component
    {
        public comp4()
          : base("comp4", "c4",
              "test trying my own stuff= baby steps",
              "dmX", "geom-test")
        {
        }
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddPointParameter("Point", "p", "Center", GH_ParamAccess.item);
            pManager.AddNumberParameter("Distance", "d", "distances to layout circles", GH_ParamAccess.item);
        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddCircleParameter("Circle", "c", "Circle", GH_ParamAccess.item);
            pManager.AddNumberParameter("Dist", "v", "distance", GH_ParamAccess.item);
            pManager.AddPointParameter("Point", "p", "point at z", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            Rhino.Geometry.Point3d pt=Rhino.Geometry.Point3d.Unset;
            double di = double.NaN;
            if (!DA.GetData(0, ref pt)) return;
            if (!DA.GetData(1, ref di)) return;

            DA.SetData(0, new Rhino.Geometry.Circle(pt, di));
            DA.SetData(1, di);
            Rhino.Geometry.Point3d pt2 = new Rhino.Geometry.Point3d(pt.X, pt.Y, pt.Z + 10);
            DA.SetData(2, pt2);
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
            get { return new Guid("c660b074-b993-49ad-a0c5-4b58b3558daf"); }
        }
    }
}
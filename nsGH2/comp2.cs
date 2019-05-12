using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace nsGH2
{
    public class comp2 : GH_Component
    {
        public comp2()
          : base("comp2", "c2",
              "dmX-test for multiple components in tab",
              "dmX", "geom-test")
        {
        }
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddCircleParameter("Circle", "C", "The Circle to Slice", GH_ParamAccess.item);
            pManager.AddLineParameter("Line", "L", "Slicing Line", GH_ParamAccess.item);
        }
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddArcParameter("Arc A", "A", "First Split result", GH_ParamAccess.item);
            pManager.AddArcParameter("Arc B", "B", "Second Split result", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            Rhino.Geometry.Circle circle = Rhino.Geometry.Circle.Unset;
            Rhino.Geometry.Line line = Rhino.Geometry.Line.Unset;

            if (!DA.GetData(0, ref circle)) return;
            if (!DA.GetData(1, ref line)) return;

            if (!circle.IsValid) { return; }
            if (!line.IsValid) { return; }

            line.Transform(Rhino.Geometry.Transform.PlanarProjection(circle.Plane));

            if (line.Length < Rhino.RhinoMath.ZeroTolerance)
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Error, "Line could not be projected to circle plane");
                return;
            }

            double t1;
            double t2;
            Rhino.Geometry.Point3d p1;
            Rhino.Geometry.Point3d p2;

            switch(Rhino.Geometry.Intersect.Intersection.LineCircle(line, circle, out t1, out p1, out t2, out p2))
            {
                case Rhino.Geometry.Intersect.LineCircleIntersection.None:
                    AddRuntimeMessage(GH_RuntimeMessageLevel.Error, "No intersections found");
                    return;

                case Rhino.Geometry.Intersect.LineCircleIntersection.Single:
                    AddRuntimeMessage(GH_RuntimeMessageLevel.Error, "Only single intersection found");
                    return;
            }

            double ct;
            circle.ClosestParameter(p1, out ct);

            Rhino.Geometry.Vector3d tan = circle.TangentAt(ct);

            DA.SetData(0, new Rhino.Geometry.Arc(p1, tan, p2));
            DA.SetData(1, new Rhino.Geometry.Arc(p1, -tan, p2));


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
            get { return new Guid("45c48953-6004-4800-992b-b4045fa677be"); }
        }
    }
}
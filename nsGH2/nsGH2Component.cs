using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace nsGH2
{
    public class nsGH2Component : GH_Component
    {
        public nsGH2Component() : base("My First", "MFC", "My First Component", "dmX", "test") {

        }
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("String", "S", "String to reverse", GH_ParamAccess.item);
            pManager.AddNumberParameter("Angle", "A", "The angle to measure", GH_ParamAccess.item);
            pManager.AddBooleanParameter("Radians", "R", "Work in Radians", GH_ParamAccess.item);
            //throw new NotImplementedException();
        }
        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("Reverse", "R", "Reversed String", GH_ParamAccess.item);
            pManager.AddNumberParameter("Sin", "sin", "the sine of the angle", GH_ParamAccess.item);
            pManager.AddNumberParameter("Cos", "cos", "the cosine of the angle", GH_ParamAccess.item);
            pManager.AddNumberParameter("Tan", "tan", "the tangent of the angle", GH_ParamAccess.item);
            //throw new NotImplementedException();
        }
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            //solve for text reverse
            string data = null;
            double angle = double.NaN;
            bool radians = false;

            //inputs from DA_Access
            if (!DA.GetData(0, ref data)) { return; } // use DA to retrieve input param: string
            if (!DA.GetData(1, ref angle)) { return; } // use DA to retrieve input param : angles
            if(!DA.GetData(2, ref radians)) { return; } // use DA to retrieve input param : radians
            if(!Rhino.RhinoMath.IsValidDouble(angle)) { return;  } // if the number is not valid 
            if (!radians)
            {
                angle = Rhino.RhinoMath.ToRadians(angle);
            }

            if (data == null) { return; }
            if (data.Length == 0) { return; }
            char[] chars = data.ToCharArray();
            System.Array.Reverse(chars);
            DA.SetData(0, new string(chars)); // for text reversal
            DA.SetData(1, Math.Sin(angle));
            DA.SetData(2, Math.Cos(angle));
            DA.SetData(3, Math.Tan(angle));
            //throw new NotImplementedException();
        }
        public override Guid ComponentGuid
        {
            get { return new Guid("178b4e5b-b0d6-43a5-a8a7-09f6adafdcc2"); }
        }
    }
}


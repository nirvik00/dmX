﻿using System;
using System.Drawing;
using Grasshopper.Kernel;

namespace nsGH2
{
    public class nsGH2Info : GH_AssemblyInfo
    {
        public override string Name
        {
            get
            {
                return "nsGH2";
            }
        }
        public override Bitmap Icon
        {
            get
            {
                //Return a 24x24 pixel bitmap to represent this GHA library.
                return null;
            }
        }
        public override string Description
        {
            get
            {
                //Return a short string describing the purpose of this GHA library.
                return "";
            }
        }
        public override Guid Id
        {
            get
            {
                return new Guid("8fe811ed-7690-47b9-bae2-302b172d9529");
            }
        }

        public override string AuthorName
        {
            get
            {
                //Return a string identifying you or your company.
                return "";
            }
        }
        public override string AuthorContact
        {
            get
            {
                //Return a string representing your preferred contact details.
                return "";
            }
        }
    }
}

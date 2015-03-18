using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using EmployeeDirectory.Models;

namespace EmployeeDirectory.Utilities
{
    public static class ApplicationUtility
    {
        public static string FormatURL(string PathWithoutVirtualDirectoryName)
        {
            ApplicationInformation appInfomation
                = ApplicationInformation.GetInstance();
            string DeploymentVirtualDirectory
                = appInfomation.DeploymentVirtualDirectory;

            if (DeploymentVirtualDirectory == "")
            {
                return PathWithoutVirtualDirectoryName;
            }

            StringBuilder SB = new StringBuilder();
            SB.Append("/");
            SB.Append(appInfomation.DeploymentVirtualDirectory);
            SB.Append("/");
            SB.Append(PathWithoutVirtualDirectoryName);

            return SB.ToString();
        }
    }
}
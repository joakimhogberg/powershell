﻿using PnP.Framework.Entities;
using PnP.Framework.Graph;
using PnP.PowerShell.Commands.Attributes;
using PnP.PowerShell.Commands.Base;
using PnP.PowerShell.Commands.Base.PipeBinds;
using System.Management.Automation;

namespace PnP.PowerShell.Commands.Graph
{
    [Cmdlet(VerbsCommon.Clear, "PnPAadGroupOwner")]
    [RequiredMinimalApiPermissions("Group.ReadWrite.All")]
    public class ClearAadGroupOwner : PnPGraphCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public AadGroupPipeBind Identity;

        protected override void ExecuteCmdlet()
        {
            GroupEntity group = null;

            if (Identity != null)
            {
                group = Identity.GetGroup(AccessToken);
            }

            if (group != null)
            {
                GroupsUtility.ClearGroupOwners(group.GroupId, AccessToken);
            }
        }
    }
}
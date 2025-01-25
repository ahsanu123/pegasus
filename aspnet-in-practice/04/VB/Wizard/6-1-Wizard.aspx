<%@ Page Language="VB" AutoEventWireup="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Wizard ID="MyWizard" runat="server" ActiveStepIndex="0" RenderOuterTable="false" DisplaySideBar="false">
            <LayoutTemplate>
                <asp:PlaceHolder ID="headerPlaceholder" runat="server" />
                <asp:PlaceHolder ID="sideBarPlaceholder" runat="server" />
                <asp:PlaceHolder ID="wizardStepPlaceholder" runat="server" />
                <asp:PlaceHolder ID="navigationPlaceholder" runat="server" />
            </LayoutTemplate>
            <SideBarTemplate>
                <asp:ListView runat="server" ID="SideBarList">
                    <LayoutTemplate>
                        <ul>
                            <li runat="server" id="itemPlaceholder" />
                        </ul>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <li runat="server" id="itemPlaceholder">
                            <asp:LinkButton runat="server" ID="SideBarButton" /></li>
                    </ItemTemplate>
                </asp:ListView>
            </SideBarTemplate>
            <StartNavigationTemplate>
                <p><asp:LinkButton ID="StartNextButton" runat="server" CommandName="MoveNext" Text="Next" /></p>
            </StartNavigationTemplate>
            <FinishNavigationTemplate>
                <p>
                    <asp:LinkButton ID="FinishButton" runat="server" CommandName="MoveComplete" Text="Finish" /></p>
            </FinishNavigationTemplate>
            <WizardSteps>
                <asp:WizardStep ID="WizardStep1" runat="server" Title="Step 1">
                    Step 1
                </asp:WizardStep>
                <asp:WizardStep ID="WizardStep2" runat="server" Title="End">
                    End!
                </asp:WizardStep>
            </WizardSteps>
        </asp:Wizard>
    </div>
    </form>
</body>
</html>

<%@ Page 
    Title="About" 
    Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeBehind="About.aspx.cs" 
    Inherits="WingtipToys.About" %>

<asp:Content 
    ID="BodyContent" 
    ContentPlaceHolderID="MainContent" 
    runat="server">

    <controls:Message 
        runat="server" 
        ID="MyMessage"
        Text="This is test">
        <ItemTemplate>
         <p>Here’s a formatted template: <%#Container.Text %></p>
        </ItemTemplate>
    </controls:Message>

    <h2><%: Title %>.</h2>
    <p>
        Viki A. Windfeldt was named the 2014 recipient of the Lorraine P. Sachs Standard of Excellence
        Award. This award was established in 2008 by the National Association of State Boards of
        Accountancy (NASBA). The Lorraine P. Sachs Award, in honor of NASBA Executive Vice President
        Emeritus Sachs, was established to recognize state board executive directors that have shown
        outstanding service and commitment to improving the effectiveness of accounting regulation, both
        locally and nationally. Viki will be presented with the Award at the NASBA Annual Conference in
        Washington DC
    </p>
    <p>
        Viki was hired in 1995 by the Nevada State Board of Accountancy (NSBA) as assistant director. Prior
        to being hired by the NSBA, Viki was with the Nevada State Board of Pharmacy for four years where
        she served as Board Coordinator. In this role, she was responsible for numerous tasks associated with
        the Board including regulatory and statutory language writing, board meeting coordination,
        renewals, licensing and enforcement. Viki brought her previous experience to improve the efficiency
        and operation of the NSBA. After establishing herself with the Board through her work Viki was
        promoted to Executive Director in 2003. 
    </p>
    <p>
        During her 19 years with the Board, Viki has been successful in building solid working relationships with
        the Nevada Society of CPAs, CPA stakeholders, state legislature and individuals on a national level.
        Under her leadership the Nevada Board has successfully: streamlined processes within the office
        environment; continued operation with a small staff; reduced overall office expenses; website and
        computer software development; online access and reporting of all programs such as license
        renewals, CPE audit submission, peer review reporting, examination application, reporting of exam
        scores and scanning for a paperless office. Viki is always looking for ways in which she can improve
        upon the level of service and communication provided to the Board, the Society, state government,
        other Board agencies as well as the licensees and the public.
    </p>

</asp:Content>

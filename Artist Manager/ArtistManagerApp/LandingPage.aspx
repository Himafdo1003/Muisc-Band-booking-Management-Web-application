<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LandingPage.aspx.cs" Inherits="ArtistManagerApp.LandingPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gravity</title>


     <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">

   

    <!-- CSS FILES -->
    <link rel="preconnect" href="https://fonts.googleapis.com">

    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>

    <link href="https://fonts.googleapis.com/css2?family=Outfit:wght@100;200;400;700&display=swap" rel="stylesheet">

    <link href="Lcss/bootstrap.min.css" rel="stylesheet">

    <link href="Lcss/bootstrap-icons.css" rel="stylesheet">

    <link href="Lcss/templatemo-festava-live.css" rel="stylesheet">

    <style>
    .rounded-button {
        border-radius: 8px;
        padding: 10px 20px;
        background-color: #007bff;
        color: #ffffff;
        border: none;
        cursor: pointer;
    }
</style>

</head>
<body>
    <form id="form1" runat="server">
        <main>

        <header class="site-header">
            <div class="container">
                <div class="row">

                    <div class="col-lg-12 col-12 d-flex flex-wrap">
                        <p class="d-flex me-4 mb-0">
                            <%--<i class="bi-person custom-icon me-2"></i>--%>
                            <strong class="text-dark">Welcome to GRAVITY</strong>
                        </p>
                    </div>

                </div>
            </div>
        </header>


        <nav class="navbar navbar-expand-lg">
            <div class="container">
                <a class="navbar-brand" href="LandingPage.aspx">
                    GRAVITY
                </a>

                <a href="StartPage.aspx" class="btn custom-btn d-lg-none ms-auto me-4">Staff</a>

                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav"
                    aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>

                <div class="collapse navbar-collapse" id="navbarNav">
                    <ul class="navbar-nav align-items-lg-center ms-auto me-lg-5">
                        <li class="nav-item">
                            <a class="nav-link click-scroll" href="#section_1">Home</a>
                        </li>

                        <li class="nav-item">
                            <a class="nav-link click-scroll" href="#section_2">About</a>
                        </li>

                        <li class="nav-item">
                            <a class="nav-link click-scroll" href="#section_3">Artists</a>
                        </li>

                        <li class="nav-item">
                            <a class="nav-link click-scroll" href="#section_4">Schedule</a>
                        </li>
                 

                        <li class="nav-item">
                            <a class="nav-link click-scroll" href="#section_6">Contact</a>
                        </li>
                    </ul>

                    <a href="StartPage.aspx" class="btn custom-btn d-lg-block d-none">Staff</a>
                </div>
            </div>
        </nav>


        <section class="hero-section" id="section_1">
            <div class="section-overlay"></div>

            <div class="container d-flex justify-content-center align-items-center">
                <div class="row">

                    <div class="col-12 mt-auto mb-5 text-center">
                        <small>WELCOME TO</small>

                        <h1 class="text-white mb-5"><b>GRAVITY</b></h1>

                        <a class="btn custom-btn smoothscroll" href="#section_2">Let's begin</a>
                    </div>

                   
                </div>
            </div>

            <div class="video-wrap">
                <video autoplay="" loop="" muted="" class="custom-video" poster="">
                    <source src="Lvideo/pexels-2022395.mp4" type="video/mp4">

                    Your browser does not support the video tag.
                </video>
            </div>
        </section>


        <section class="about-section section-padding" id="section_2">
            <div class="container">
                <div class="row">

                    <div class="col-lg-6 col-12 mb-4 mb-lg-0 d-flex align-items-center">
                        <div class="services-info">
                            <h2 class="text-white mb-4">About Gravity</h2>

                            <p class="text-white">
                                Gravity, under the leadership of Mr.Kaweesha Fernando was established as a musical band in 2019 and now has marked it’s acme in the music industry of Sri Lanka winning the hearts of millions both locally and globally with the newness and the remarkable change it has brought to the industry as a versatile band covering a wide range of music genres such as pop, semi-rock, and western classical. </p>                    
                           

                            <h6 class="text-white mt-4"></h6>

                            <p class="text-white"></p>

                            <h6 class="text-white mt-4"></h6>

                            <p class="text-white"></p>
                        </div>
                    </div>

                    <div class="col-lg-6 col-12">
                        <div class="about-text-wrap">
                            <img src="Limages/12.jpg" class="about-image img-fluid">

                            <div class="about-text-info d-flex">
                                <div class="d-flex">
                                  
                                </div>


                                <div class="ms-4">
                                    <h3>Book Us for your Happy Day</h3>

                                   
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </section>


        <section class="artists-section section-padding" id="section_3">
            <div class="container">
                <div class="row justify-content-center">

                    <div class="col-12 text-center">
                        <h2 class="mb-4">Meet Artists</h1>
                    </div>

                    <div class="col-lg-5 col-12">
                        <div class="artists-thumb">
                            <div class="artists-image-wrap">
                                <img src="Limages/artists/1.jpeg"
                                    class="artists-image img-fluid">
                            </div>

                            <div class="artists-hover">
                                <p>
                                   Introducing Devin Don, the heartbeat behind Gravity Band's unforgettable sound. As our master of rhythm, Devin's drumming prowess electrifies stages and ignites crowds with every beat. His unmatched talent and dedication infuse our music with an irresistible energy that keeps audiences on their feet. Join us as we defy gravity with Devin's driving force leading the way.
                                </p>
                            </div>
                        </div> 
                        <div class="artists-thumb">
                            <div class="artists-image-wrap">
                                <img src="Limages/artists/2.jpeg"
                                    class="artists-image img-fluid">
                            </div>

                            <div class="artists-hover">
                                <p>
                               Meet Rukshan Mudliyer, the charismatic voice and soulful strings of Gravity Band. As our lead vocalist and guitarist, Rukshan captivates audiences with his dynamic stage presence and heartfelt performances. His emotive vocals and skillful guitar melodies intertwine to create an unforgettable sonic experience. Join us as we are serenaded by Rukshan's powerful voice and entranced by his masterful guitar work, guiding us through a musical journey filled with passion and energy
                                    </p>
                            </div>
                        </div>

                    </div>

                    <div class="col-lg-5 col-12">
                        <div class="artists-thumb">
                            <div class="artists-image-wrap">
                               <img src="Limages/artists/3.jpeg"
                                    class="artists-image img-fluid">
                            </div>

                            <div class="artists-hover">
                                <p>
                                   Introducing Rashean Fernando, the vocal powerhouse of Gravity Band. With a voice that resonates with passion and emotion, Rashean brings soulful depth to our performances. His captivating presence and versatile range breathe life into every song, leaving audiences spellbound. Join us as we are swept away by Rashean's enchanting vocals, guiding us through melodies that linger long after the music ends.
                                </p>
                            </div>
                        </div>

                        <div class="artists-thumb">
                            <img src="Limages/artists/4.jpeg"
                                class="artists-image img-fluid">

                            <div class="artists-hover">
                                <p>
                                   Meet Kaweesha Fernando, the soulful anchor of Gravity Band's melodies. With finesse and flair, Kaweesha's bass guitar expertise lays down the foundation of our sound, weaving together rhythm and harmony with unmatched skill. His passion for music resonates in every note, adding depth and groove to our performances. Join us as we groove to the rhythm of Kaweesha's unforgettable bass lines, grounding our music in pure sonic magic.
                                </p>
                            </div>
                        </div>
                    </div>

                   

                     <div class="col-lg-5 col-12">
                        <div class="artists-thumb">
                            <div class="artists-image-wrap">
                               <img src="Limages/artists/5.jpeg"
                                    class="artists-image img-fluid">
                            </div>

                            <div class="artists-hover">
                                <p>
                                
                                Meet Sandul Fernando, the maestro of melody in Gravity Band. With fingers that dance across the strings, Sandul's lead guitar mastery weaves intricate harmonies and electrifying solos that mesmerize audiences. His soulful expression and boundless creativity add depth and emotion to our sound, creating an unforgettable musical experience. Join us as we soar to new heights with Sandul's captivating guitar melodies leading the way    
                                </p>
                            </div>
                        </div>

                        <div class="artists-thumb">
                            <img src="Limages/artists/6.jpeg"
                                class="artists-image img-fluid">

                            <div class="artists-hover">
                                <p>
                                 Introducing Dinith Perera, the keyboard virtuoso of Gravity Band. With finesse and flair, Dinith's mastery of the keys infuses our music with rich layers of melody and harmony. His versatility and creativity add depth and dimension to our sound, elevating every performance to new heights. Join us as we journey through sonic landscapes guided by Dinith's mesmerizing keyboard magic, where each note is a testament to his musical brilliance.

                                </p>
                            </div>
                        </div>
                    </div>


                </div>
            </div>
        </section>


        <section class="schedule-section section-padding" id="section_4">
            <div class="container">
                <div class="row">

                    <div class="col-12 text-center">
                        <h2 class="text-white mb-4">Event Schedule</h1>

                            <div class="table-responsive">
                               <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>

                                 <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                <ContentTemplate>
                                    <asp:Calendar ID="calendar" runat="server" BackColor="White"
                                        FirstDayOfWeek="Monday"  Selectable="False"
        BorderColor="Black" BorderWidth="1px"
        Font-Names="Calibri" Font-Size="9pt" ForeColor="Black" Height="100%"
        ondayrender="Calendar1_DayRender" Width="100%"  Font-Bold="True" OnSelectionChanged="calendar_SelectionChanged"  NextMonthText="&gt;&gt;" data-toggle="modal" data-target="#exampleModalCenter"  PrevMonthText="&lt;&lt;" CssClass="myCalendar"  OnVisibleMonthChanged="calendar_VisibleMonthChanged" CellSpacing="15" CellPadding="5" BorderStyle="Solid" ShowGridLines="True"  >
         <OtherMonthDayStyle ForeColor="white" />
            <DayStyle CssClass="myCalendarDay" ForeColor="Black" Height="80px" Width="180px" HorizontalAlign="center" VerticalAlign="Top" />
            <DayHeaderStyle  ForeColor="Black" HorizontalAlign="Center" VerticalAlign="Middle" />
<SelectedDayStyle Font-Bold="True" Font-Size="12px" CssClass="myCalendarSelector" />
            <TodayDayStyle CssClass="myCalendarToday" BackColor="#AFD5F3" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
            <SelectorStyle CssClass="myCalendarSelector" />
            <NextPrevStyle CssClass="myCalendarNextPrev" />
            <TitleStyle CssClass="myCalendarTitle" />
                                  
    </asp:Calendar>

               </ContentTemplate> </asp:UpdatePanel>

                            </div>
                    </div>
                </div>
            </div>
        </section>


       

        <section class="contact-section section-padding" id="section_6">
            <div class="container">
                <div class="row">

                    <div class="col-lg-8 col-12 mx-auto">
                        <h2 class="text-center mb-4">Interested? Let's talk</h2>

                        <nav class="d-flex justify-content-center">
                            <div class="nav nav-tabs align-items-baseline justify-content-center" id="nav-tab"
                                role="tablist">
                                <button class="nav-link active" id="nav-ContactForm-tab" data-bs-toggle="tab"
                                    data-bs-target="#nav-ContactForm" type="button" role="tab"
                                    aria-controls="nav-ContactForm" aria-selected="false">
                                    <h5>Contact Form</h5>
                                </button>

                                <button class="nav-link" id="nav-ContactMap-tab" data-bs-toggle="tab"
                                    data-bs-target="#nav-ContactMap" type="button" role="tab"
                                    aria-controls="nav-ContactMap" aria-selected="false">
                                    <h5>Google Maps</h5>
                                </button>
                            </div>
                        </nav>

                        <div class="tab-content shadow-lg mt-5" id="nav-tabContent">
                            <div class="tab-pane fade show active" id="nav-ContactForm" role="tabpanel"
                                aria-labelledby="nav-ContactForm-tab">
                                <form class="custom-form contact-form mb-5 mb-lg-0" action="#" method="post"
                                    role="form">
                                    <div class="contact-form-body">
                                        <div class="row">
                                            <div class="col-lg-6 col-md-6 col-12">
                                                <asp:TextBox ID="NameTB" runat="server" CssClass="form-control" placeholder="Full name"></asp:TextBox>
   
                                            </div>

                                            <div class="col-lg-6 col-md-6 col-12">
                                                <asp:TextBox ID="TeleTB" runat="server" CssClass="form-control" TextMode="Number" placeholder="Mobile Number"></asp:TextBox>
 
                                            </div>
                                        </div>
                                        <br />
                                         <asp:TextBox ID="EmailTB" runat="server" CssClass="form-control" placeholder="Email"></asp:TextBox>
 
                                        <br />

                                         <asp:TextBox ID="DetailsTB" runat="server" CssClass="form-control" TextMode="MultiLine" Height="70px" placeholder="Type Here..."></asp:TextBox>
 
                                        <br />

                                        <div class="col-lg-4 col-md-10 col-8 mx-auto">
                                            
                                            <asp:Button ID="SubmitBtn" runat="server" Text="Send message" BackColor="#EE5106" ForeColor="White" Font-Bold="True"  CssClass="rounded-button" OnClick="SubmitBtn_Click" />

                                        </div>
                                    </div>
                                </form>
                            </div>

                            <div class="tab-pane fade" id="nav-ContactMap" role="tabpanel"
                                aria-labelledby="nav-ContactMap-tab">
                                <iframe class="google-map"
                                    src="https://www.google.com/maps/embed/v1/place?q=Chilaw,+Sri+Lanka&key=AIzaSyBFw0Qbyq9zTFTd-tUY6dZWTgaQzuU17R8"
                                    width="100%" height="450" style="border:0;" allowfullscreen="" loading="lazy"
                                    referrerpolicy="no-referrer-when-downgrade"></iframe>
                                <!-- You can easily copy the embed code from Google Maps -> Share -> Embed a map // -->
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </section>
    </main>


    <footer class="site-footer">
        <div class="site-footer-top">
            <div class="container">
                <div class="row">

                    <div class="col-lg-6 col-12">
                        <h2 class="text-white mb-lg-0">Gravity</h2>
                    </div>

                    <div class="col-lg-6 col-12 d-flex justify-content-lg-end align-items-center">
                        <ul class="social-icon d-flex justify-content-lg-end">
                            <li class="social-icon-item">
                                <a href="#" class="social-icon-link">
                                    <span class="bi-twitter"></span>
                                </a>
                            </li>

                            <li class="social-icon-item">
                                <a href="#" class="social-icon-link">
                                    <span class="bi-apple"></span>
                                </a>
                            </li>

                            <li class="social-icon-item">
                                <a href="#" class="social-icon-link">
                                    <span class="bi-instagram"></span>
                                </a>
                            </li>

                            <li class="social-icon-item">
                                <a href="#" class="social-icon-link">
                                    <span class="bi-youtube"></span>
                                </a>
                            </li>

                            <li class="social-icon-item">
                                <a href="#" class="social-icon-link">
                                    <span class="bi-pinterest"></span>
                                </a>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>

        <div class="container">
            <div class="row">

                <div class="col-lg-6 col-12 mb-4 pb-2">
                    <h5 class="site-footer-title mb-3">Links</h5>

                    <ul class="site-footer-links">
                        <li class="site-footer-link-item">
                            <a href="#" class="site-footer-link">Home</a>
                        </li>

                        <li class="site-footer-link-item">
                            <a href="#" class="site-footer-link">About</a>
                        </li>

                        <li class="site-footer-link-item">
                            <a href="#" class="site-footer-link">Artists</a>
                        </li>

                        <li class="site-footer-link-item">
                            <a href="#" class="site-footer-link">Schedule</a>
                        </li>

                        

                        <li class="site-footer-link-item">
                            <a href="#" class="site-footer-link">Contact</a>
                        </li>
                    </ul>
                </div>

                <div class="col-lg-3 col-md-6 col-12 mb-4 mb-lg-0">
                    <h5 class="site-footer-title mb-3">Have a question?</h5>

                    <p class="text-white d-flex mb-1">
                        0322222000
                    </p>

                    <p class="text-white d-flex">
                        <a href="#" class="site-footer-link">
                            gravity@gmail.com
                        </a>
                    </p>
                </div>

                <div class="col-lg-3 col-md-6 col-11 mb-4 mb-lg-0 mb-md-0">
                    <h5 class="site-footer-title mb-3">Location</h5>

                    <p class="text-white d-flex mt-3 mb-2">
                        Chilaw, Sri Lanka</p>

                    
                </div>
            </div>
        </div>

        <div class="site-footer-bottom">
            <div class="container">
                <div class="row">

                    <div class="col-lg-3 col-12 mt-5">
                        <p class="copyright-text">Copyright © 2024 GRAVITY</p>
                        
                    </div>

                   
                </div>
            </div>
        </div>
    </footer>

    <!--

T e m p l a t e M o

-->

    <!-- JAVASCRIPT FILES -->
   <script src="Ljs/jquery.min.js"></script>
    <script src="Ljs/bootstrap.min.js"></script>
    <script src="Ljs/jquery.sticky.js"></script>
    <script src="Ljs/click-scroll.js"></script>
    <script src="Ljs/custom.js"></script>

    </form>
</body>
</html>


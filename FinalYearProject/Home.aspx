<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="FinalYearProject.HomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="http://code.jquery.com/jquery-1.4.4.min.js"></script>
    <script src="booklet/jquery.easing.1.3.js"></script>
    <script src="booklet/jquery.booklet.1.1.0.min.js"></script>
    <link href="booklet/jquery.booklet.1.1.0.css" rel="stylesheet" />
    <link href="notebook%20css/style.css" rel="stylesheet" />
    <script src="cufon/cufon-yui.js"></script>
    <script src="cufon/ChunkFive_400.font.js"></script>
    <script src="cufon/Note_this_400.font.js"></script>
    <script type="text/javascript">
	Cufon.replace('h1,p,.b-counter');
	Cufon.replace('.book_wrapper a', {hover:true});
	Cufon.replace('.title', {textShadow: '1px 1px #C59471', fontFamily:'ChunkFive'});
	Cufon.replace('.reference a', {textShadow: '1px 1px #C59471', fontFamily:'ChunkFive'});
	Cufon.replace('.loading', {textShadow: '1px 1px #000', fontFamily:'ChunkFive'});
		</script>
</asp:Content>

<asp:Content ID="Content2" runat="server" contentplaceholderid="ContentPlaceHolder1">
    <div class="navbar navbar-inverse navbar-fixed-top headroom" >
        <div class="container">
            <div>
				<!-- Button for smallest screens -->
				        <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                            <span class="icon-bar"></span><span class="icon-bar"></span><span class="icon-bar"></span>
                </button>
            </div>
            <div class="navbar-collapse collapse">
                <ul class="nav navbar-nav pull-left">
                    <li><a href="Home.aspx">Home</a></li>

                </ul>
                <img src="siteimages/logo.png" alt="Progressus HTML5 template" class="imgiconcss" />
              
                <ul class="nav navbar-nav pull-right">
                    <li><a href="TherapistSignUp.aspx">Sign Up</a></li>
                    <li><a href="TherapistLogin.aspx">Login</a></li>
                </ul>
            </div>
                    <!--/.nav-collapse -->

		        </div>
    </div>
	<!-- /.navbar -->
            <asp:Panel runat="server" HorizontalAlign="Center" >
                <br />
                <br />
                <br />
                <br />
    </asp:Panel>

    <div class="book_wrapper">
			<a id="next_page_button"></a>
			<a id="prev_page_button"></a>
			<div id="loading" class="loading">Loading pages...</div>
			<div id="mybook" style="display:none;">
				<div class="b-load">
					<div>
						<img src="siteimages/1.jpg" alt=""/>
						<h1>What is Music Therapy?</h1>
						<p>-The clinical and evidence-based use of music interventions to accomplish individualized goals within a therapeutic relationship.
						<br/>
                            <br />
						-Addresses physical, emotional, cognitive, and social needs of individuals.
						<br/>
						<br/>
						-Mostly used in medical fields to provide an alternative route of therapy.
						</p>
						 
					</div>
					<div>
						<img src="siteimages/1.jpg" alt="" />
						<h1>Diseases and Music Therapy </h1>
						<p>List of Diseases currently using music therapy
						<br/>
						<br/>
						-Alzeihmers's
						<br/>
						<br/>
						-Parkinsons
						<br/>
						<br/>
						-Mental Illness
						<br/>
						<br/>
						-Autism
						</p>
						
					</div>
					<div>
						<img src="siteimages/1.jpg" alt="" />
						<h1> Health Benefits</h1>
						<p>-Music Therapy simulates brainwaves
						<br/>
						
						The brain is no different than any organ, in that when it is exercised, it becomes sharper, stronger and more useful.
						<br/>
						<br />
						-Music Therapy is Non-invasive and easy
						<br/>
						
						Unlike traditional methods of medicine such as chemotherapy or chugging pills, music therapy is non invasive requiring only listening to be effective
						</p>
						
					</div>
					<div>
						<img src="siteimages/1.jpg" alt="" />
						<h1>Utilization of Music Therapy</h1>
						<p>-Hospitals
						<br/>
					    <br />
						 Alleviate pain in conjunction with anesthesia or pain medication, often induced to sleep
						<br/>
						<br />
						-Nursing Homes
						<br/>
						<br />
						Use with elderly persons to increase/maintain their level of physical/mental/emotional functioning.
						
						</p>
	
					</div>
					<div>
						<img src="siteimages/1.jpg" alt="" />
						<h1> Music Types in Music Therapy</h1>
						<p>
						
						 Genre and type of instrument is tailored to the individual and to the goals that are established between the client and the music therapist.
						 <br/>
						 <br/>
						 Since music choice/usage is tailored to each client’s needs and preferences, there is really no "most common" type of music or instrument
						<br/>
						<br/>
						All styles of music have the potential to be useful in effecting change in a client’s or a patient's life.
					
					
						</p>
					</div>
					<div>
						<img src="siteimages/1.jpg" alt="" />
						<h1>More Information</h1>
						<p>For information visit these links
						<br/>
						<br/>
						<a href="https://en.wikipedia.org/wiki/Music_therapy">Wikipedia Article on Music Therapy </a>
						<br/>
						<br/>
						<a href="http://www.musictherapy.org/about/musictherapy/">American Music Therapy Association</a>
						<br/> 
						<br/>
						<a href="http://www.musictherapy.org/faq/">American Music Therapy Association FAQ </a>
						
						</p>

					</div>
				</div>
			</div>
		</div>
        <div>
        
		</div>


    <footer id="footer" class="top-space">
        <div class="footer2">
            <div class="container">
                <div class="row">
                    <div class="col-md-6 widget">
                        <div class="widget-body">
                            <p class="text-right">
                                Copyright &copy; 2015,Mohd Sherrez Kader
                            </p>
                        </div>
                    </div>
                </div>
                        <!-- /row of widgets -->
			        </div>
        </div>
    </footer>
		




	<!-- JavaScript libs are placed at the end of the document so the pages load faster -->
	
	
	<script src="webcss/js/headroom.min.js"></script>
	<script src="webcss/js/jQuery.headroom.min.js"></script>
	<script src="webcss/js/template.js"></script>

            <script type="text/javascript">
			$(function($) {
				var $mybook 		= $('#mybook');
				var $bttn_next		= $('#next_page_button');
				var $bttn_prev		= $('#prev_page_button');
				var $loading		= $('#loading');
				var $mybook_images	= $mybook.find('img');
				var cnt_images		= $mybook_images.length;
				var loaded			= 0;
				//preload all the images in the book,
				//and then call the booklet plugin

				$mybook_images.each(function(){
					var $img 	= $(this);
					var source	= $img.attr('src');
					$('<img/>').load(function(){
						++loaded;
						if(loaded == cnt_images){
							$loading.hide();
							$bttn_next.show();
							$bttn_prev.show();
							$mybook.show().booklet({
								name:               null,                            // name of the booklet to display in the document title bar
								width:              800,                             // container width
								height:             500,                             // container height
								speed:              600,                             // speed of the transition between pages
								direction:          'LTR',                           // direction of the overall content organization, default LTR, left to right, can be RTL for languages which read right to left
								startingPage:       0,                               // index of the first page to be displayed
								easing:             'easeInOutQuad',                 // easing method for complete transition
								easeIn:             'easeInQuad',                    // easing method for first half of transition
								easeOut:            'easeOutQuad',                   // easing method for second half of transition

								closed:             true,                           // start with the book "closed", will add empty pages to beginning and end of book
								closedFrontTitle:   null,                            // used with "closed", "menu" and "pageSelector", determines title of blank starting page
								closedFrontChapter: null,                            // used with "closed", "menu" and "chapterSelector", determines chapter name of blank starting page
								closedBackTitle:    null,                            // used with "closed", "menu" and "pageSelector", determines chapter name of blank ending page
								closedBackChapter:  null,                            // used with "closed", "menu" and "chapterSelector", determines chapter name of blank ending page
								covers:             false,                           // used with  "closed", makes first and last pages into covers, without page numbers (if enabled)

								pagePadding:        10,                              // padding for each page wrapper
								pageNumbers:        true,                            // display page numbers on each page

								hovers:             false,                            // enables preview pageturn hover animation, shows a small preview of previous or next page on hover
								overlays:           false,                            // enables navigation using a page sized overlay, when enabled links inside the content will not be clickable
								tabs:               false,                           // adds tabs along the top of the pages
								tabWidth:           60,                              // set the width of the tabs
								tabHeight:          20,                              // set the height of the tabs
								arrows:             false,                           // adds arrows overlayed over the book edges
								cursor:             'pointer',                       // cursor css setting for side bar areas

								hash:               false,                           // enables navigation using a hash string, ex: #/page/1 for page 1, will affect all booklets with 'hash' enabled
								keyboard:           true,                            // enables navigation with arrow keys (left: previous, right: next)
								next:               $bttn_next,          			// selector for element to use as click trigger for next page
								prev:               $bttn_prev,          			// selector for element to use as click trigger for previous page

								menu:               null,                            // selector for element to use as the menu area, required for 'pageSelector'
								pageSelector:       false,                           // enables navigation with a dropdown menu of pages, requires 'menu'
								chapterSelector:    false,                           // enables navigation with a dropdown menu of chapters, determined by the "rel" attribute, requires 'menu'

								shadows:            true,                            // display shadows on page animations
								shadowTopFwdWidth:  166,                             // shadow width for top forward anim
								shadowTopBackWidth: 166,                             // shadow width for top back anim
								shadowBtmWidth:     50,                              // shadow width for bottom shadow

								before:             function($){},                    // callback invoked before each page turn animation
								after:              function($){}                     // callback invoked after each page turn animation
							});
							Cufon.refresh();
						}
					}).attr('src',source);
				});
				
			});
        </script>
        </asp:Content>



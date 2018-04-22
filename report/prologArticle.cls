%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
% Programming/Coding Assignment
% LaTeX Template
%
% This template has been downloaded from:
% http://www.latextemplates.com
%
% Original author:
% Ted Pavlic (http://www.tedpavlic.com)
%
% modified by:
% Olivier Wenger
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

%----------------------------------------------------------------------------------------
%	PACKAGES AND OTHER DOCUMENT CONFIGURATIONS
%----------------------------------------------------------------------------------------
\ProvidesClass{prologArticle}[2017/04/26 version 1.00]
\NeedsTeXFormat{LaTeX2e}

\ProcessOptions \relax
\LoadClass{article}

\RequirePackage[utf8]{inputenc} % required for french accent
\RequirePackage[T1]{fontenc} % required for french accent
\RequirePackage[francais]{babel} % required for french language
\RequirePackage{fancyhdr} % Required for custom headers
\RequirePackage{lastpage} % Required to determine the last page for the footer
\RequirePackage{extramarks} % Required for headers and footers
\RequirePackage[usenames,dvipsnames]{color} % Required for custom colors
\RequirePackage{graphicx} % Required to insert images
\RequirePackage{listings} % Required for insertion of code
\RequirePackage{courier} % Required for the courier font
\RequirePackage{pgfkeys} % no idea what this is for
\RequirePackage[left=2.5cm,right=2.5cm,top=2.5cm,bottom=2cm]{geometry} % required for margin
\RequirePackage{xcolor} % required for custom color
\RequirePackage{sectsty} % required for colored section
\RequirePackage[usenames,dvipsnames]{color} % Required for custom colors
\RequirePackage{tikz}
% \RequirePackage{tikz-qtree} % tree
\RequirePackage{graphicx}
\RequirePackage[11pt]{moresize}




\linespread{1.1} % Line spacing

% Set up the header and footer
\pagestyle{fancy}
\lhead{\textcolor{astral}{\getvalue{meta/date}}} % Top left header
\rhead{\getvalue{meta/author}} % Top center head
\chead{\firstxmark} % Top right header
\lfoot{\lastxmark} % Bottom left footer
\cfoot{} % Bottom center footer
\rfoot{Page\ \thepage\ of\ \protect\pageref{LastPage}} % Bottom right footer
\renewcommand\headrulewidth{0.4pt} % Size of the header rule
\renewcommand\footrulewidth{0.4pt} % Size of the footer rule

\setlength\parindent{0pt} % Removes all indentation from paragraphs





% Commands for the key/value variables system
\newcommand{\setvalue}[1]{\pgfkeys{/variables/#1}}
\newcommand{\getvalue}[1]{\pgfkeysvalueof{/variables/#1}}
\newcommand{\declare}[1]{%
    \pgfkeys{
        /variables/#1.is family,
        /variables/#1.unknown/.style = {\pgfkeyscurrentpath/\pgfkeyscurrentname/.initial = ##1}
    }%
}

%----------------------------------------------------------------------------------------
%	CODE INCLUSION CONFIGURATION
%----------------------------------------------------------------------------------------
% Commands for the key/value variables system



% Creates a new command to include a perl script, the first parameter is the filename of the script (without .pl), the second parameter is the caption


%----------------------------------------------------------------------------------------
%	DOCUMENT STRUCTURE COMMANDS
%	Skip this unless you know what you're doing
%----------------------------------------------------------------------------------------


%----------------------------------------------------------------------------------------
%	NAME AND CLASS SECTION
%----------------------------------------------------------------------------------------
\declare{}
\declare{meta/}
\declare{formatting/}
\declare{formating/listings/}
\setvalue{meta/author = Owen McGill\& Karim Romanens \& Olivier Wenger}
\setvalue{meta/title = S00 put text there}
\setvalue{meta/class = Game Design and Development}
\setvalue{meta/classInstructor = Maurizio Caon \& Maurizio Rigamonti}
\setvalue{meta/className = I-3}
\setvalue{meta/date = \today}
\setvalue{formatting/section = \Large\raggedright}
\setvalue{formatting/subsection = \large\raggedright}
\setvalue{formatting/subsubsection = \raggedright}


% Settings for page layouts
\fancypagestyle{nostyle}{%
    \fancyhf{}
    \renewcommand{\headrulewidth}{0pt}
    \renewcommand{\footrulewidth}{0pt}
}
\fancypagestyle{standardstyle}{%
    \fancyhf{}

    %\fancyhead[C]{\getvalue{meta/class}}
    \fancyhead[L]{\textcolor{astral}{\getvalue{meta/date}}}
    \fancyhead[R]{\textcolor{astral}{\getvalue{meta/author}}}

    \fancyfoot[C]{\textcolor{astral}{\thepage /\pageref{LastPage}}}
    % \fancyfoot[R]{\thepage / \pageref{LastPage}}
    % \fancyfoot[L]{\getvalue{meta/title}}

    \renewcommand{\headrulewidth}{0pt}
    \renewcommand{\footrulewidth}{0.7pt}
}
\fancypagestyle{titlestyle}
{
        \fancyhf{}
    \fancyhead[c]{\includegraphics[width=\textwidth]{res/titleHeader.png}}
}
\pagestyle{standardstyle}

% color for theme

\definecolor{astral}{RGB}{46,116,181}
\subsectionfont{\color{astral}}
\sectionfont{\color{astral}}
\title{\color{astral}}

%itemize layout
%\renewcommand{\labelitemi}{$bullet$}
\renewcommand{\labelitemi}{$\bullet$}

%----------------------------------------------------------------------------------------
%   Code Layout
%----------------------------------------------------------------------------------------
% Lstlistings styles

\definecolor{codegreen}{rgb}{0,0.75,0}
\definecolor{codegray}{rgb}{0.5,0.5,0.5}
\definecolor{codepurple}{rgb}{0.38,0,0.62}
\definecolor{codewhite}{rgb}{1,1,1}
\definecolor{codeblack}{rgb}{0,0,0}
\definecolor{codeblue}{rgb}{0,0,0.8}

\definecolor{MyDarkGreen}{rgb}{0.0,0.4,0.0} % This is the color used for comments
\lstloadlanguages{Java} % Load Perl syntax for listings, for a list of other languages supported see: ftp://ftp.tex.ac.uk/tex-archive/macros/latex/contrib/listings/listings.pdf
\lstset{language=Java, % Use Perl in this example
        frame=single, % Single frame around code
        basicstyle=\ssmall\ttfamily, % Use small true type font
        keywordstyle=[1]\color{codepurple}\bf, % Perl functions bold and blue
        keywordstyle=[2]\color{Purple}, % Perl function arguments purple
        keywordstyle=[3]\color{codeblue}\underbar, % Custom functions underlined and blue
        identifierstyle=, % Nothing special about identifiers
        commentstyle=\usefont{T1}{pcr}{m}{sl}\color{MyDarkGreen}\ssmall, % Comments small dark green courier font
        stringstyle=\color{codeblue}, % Strings are purple
        showstringspaces=false, % Don't put marks in string spaces
        tabsize=4, % 5 spaces per tab
        % morecomment=[s][\color{codegray}]{@}{\ }
        %
        % Put standard Perl functions not included in the default language here
        morekeywords={rand},
        %
        % Put Perl function parameters here
        morekeywords=[2]{on, off, interp},
        %
        % Put user defined functions here
        morekeywords=[3]{test},
        %
        morecomment=[l][\color{Blue}]{...}, % Line continuation (...) like blue comment
        numbers=left, % Line numbers on left
        firstnumber=1, % Line numbers start with line 1
        numberstyle=\tiny\color{codeblack}, % Line numbers are blue and small
        stepnumber=5 % Line numbers go in steps of 5
}


%----------------------------------------------------------------------------------------
%	TITLE PAGE
%----------------------------------------------------------------------------------------
% \titlehead{\centering\inc ludegraphics[width=\textwidth]{res/titleHeader.png}} %\def\@maketitle{
%\raggedright
%\includegraphics[width=\textwidth]{res/titleHeader.png}[22ex]
%\begin{center}
%{\Huge \bfseries \sffamily \@title }\\[4ex]
%{\Large  \@author}\\[4ex]
%\@date\\[8ex]
%\includegraphics[width = 40mm]{image.png}

%\chead{\includegraphics[width=\textwidth]{res/titleHeader.png}}
\title{
\includegraphics[width=\textwidth]{res/titleHeader.png}
\vspace{1in}\\
\vspace{0in}
\textmd{\textbf{\textcolor{astral}{\Huge\getvalue{meta/class}: \getvalue{meta/title}}}}\\
\normalsize\vspace{0.1in}\small{\textcolor{astral}{\ \getvalue{meta/date}}}\\
\vspace{0.1in}\large{\textit{\textcolor{astral}{Professeurs: \getvalue{meta/classInstructor}}}}
\vspace{3in}
}

\author{\textcolor{astral}{\textbf{\getvalue{meta/author}}}\\
\normalsize\vspace{0.1in}\small{\textcolor{astral}{\getvalue{meta/className}}}}
\date{} % Insert date here if you want it to appear below your name



%----------------------------------------------------------------------------------------
% builds the document's beginning stuff
\newcommand{\buildtitle}{%
    \maketitle
    \setcounter{tocdepth}{3}
    \pagestyle{nostyle}
    \thispagestyle{nostyle}
    \newpage
    \newpage
    \tableofcontents
    \newpage
    \setcounter{page}{1}
    \pagestyle{standardstyle}
}

% section numbering
\setcounter{secnumdepth}{0} % Removes default section numbers

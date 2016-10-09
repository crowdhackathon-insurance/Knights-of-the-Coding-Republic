# Project ILIDA 
#### Ηλεκτρονική Υπηρεσία Διαχείρισης Ατυχήματος

![alt text](https://github.com/crowdhackathon-insurance/Knights-of-the-Coding-Republic/blob/master/ilida-design/Design/Icons/ilida_high_res.png?raw=true "ILIDA logo" )

Project ILIDA is a platform that solves the problem of accident submition and management in grand scale. It is designed to act in a national scope, providing the right tools and support on every interested party, from the final consumer, to insurance companies, or even the police and the national emergency aid center.

The platform consists of various modules and sub-modules, four of them are presented here as a MVP.
* Mobile app for consumers
* Mobile app for experts
* Web app for backoffice operators
* Restful Core API

![](https://github.com/crowdhackathon-insurance/Knights-of-the-Coding-Republic/blob/master/ilida-design/Design/ILIDA_USE_CASE.v.1.0.png?raw=true)

## Phone App - consumers
The public consumer app is used to easily submit an accident and track it's progress.
![](https://github.com/crowdhackathon-insurance/Knights-of-the-Coding-Republic/blob/master/ilida-design/Design/MD01%20-%20PUBLIC/MD01_SPLASH.png?raw=true)
![](https://github.com/crowdhackathon-insurance/Knights-of-the-Coding-Republic/blob/master/ilida-design/Design/MD01%20-%20PUBLIC/SC000-Insure-Login,-Public-%5BMD01%5D.png?raw=true)
![](https://github.com/crowdhackathon-insurance/Knights-of-the-Coding-Republic/blob/master/ilida-design/Design/MD01%20-%20PUBLIC/SC002-Accident-Tracking-List,-Public-%5BMD01%5D.png?raw=true)
![](https://github.com/crowdhackathon-insurance/Knights-of-the-Coding-Republic/blob/master/ilida-design/Design/MD01%20-%20PUBLIC/SC003-Accident-Submit,-Public-%5BMD01%5D.png?raw=true)
![](https://github.com/crowdhackathon-insurance/Knights-of-the-Coding-Republic/blob/master/ilida-design/Design/MD01%20-%20PUBLIC/SC004-Accident,-Public-%5BMD01%5D.png?raw=true)

## Tablet App - experts
The expert app is used by experts that register and evaluate accident data. This app will notify experts in the vicinity of an accident accepted by the backoffice system. An expert can accept the accident and move to it's location.
![](https://github.com/crowdhackathon-insurance/Knights-of-the-Coding-Republic/blob/master/ilida-design/Design/MD02%20-%20EXPERT/SC022%20Accident%20Tracking%20List,%20Experts%20%5BMD02%5D.png?raw=true)
![](https://github.com/crowdhackathon-insurance/Knights-of-the-Coding-Republic/blob/master/ilida-design/Design/MD02%20-%20EXPERT/SC023-Accident,-Experts,-Α.png?raw=true)
![](https://github.com/crowdhackathon-insurance/Knights-of-the-Coding-Republic/blob/master/ilida-design/Design/MD02%20-%20EXPERT/SC023-Accident,-Experts,-Β.png?raw=true)
![](https://github.com/crowdhackathon-insurance/Knights-of-the-Coding-Republic/blob/master/ilida-design/Design/MD02%20-%20EXPERT/SC023-Accident,-Experts,-Γ.png?raw=true)
![](https://github.com/crowdhackathon-insurance/Knights-of-the-Coding-Republic/blob/master/ilida-design/Design/MD02%20-%20EXPERT/SC023-Accident,-Experts,-Ε.png?raw=true)

## Web App - backoffice operators
The backoffice app is used by the operation center. Operators will manage and validate all accidents that pass from the platform.
![](https://github.com/crowdhackathon-insurance/Knights-of-the-Coding-Republic/blob/master/ilida-design/Design/MD03%20-%20BACKOFFICE/SC030-Login,-Backoffice-%5BMD03%5D.png?raw=true)
![](https://github.com/crowdhackathon-insurance/Knights-of-the-Coding-Republic/blob/master/ilida-design/Design/MD03%20-%20BACKOFFICE/SC031-Main-&-Accident-Tracking-List,-Backoffice-%5BMD03%5D.png?raw=true)

## RESTful API 
In the core of the platform resides a RESTful API in ASP.NET Web API, this API services all the current and future modules of the platform. There is currently no documentation available, but you can see the Domain Model.
![](https://github.com/crowdhackathon-insurance/Knights-of-the-Coding-Republic/blob/master/ilida-design/Design/Domain%20Model.png?raw=true)

# Team7

DVN Hackathon

Compressor failure prediciton problem

Technologies used
* Angular
* Angular Material
* SignalR
* ASP.NET
* Azure ML studio
* Azure App Services

Things we learned
* Data Science is wicked hard
* Azure ML Studio let us forget about tooling and focus on solving the problem
* Azure ML Studio has a nice built-in REST service feature for trained models, super easy
* SignalR was new to most of the team, and websockets can make for a very nice user experience
* Data Science is full of dark magicks

What we did
* Tried many different ways to build a decent model for the provided dataset
* Did a ton of analysis and data cleaning to arrive at a model that is predictive in some cases.
* Website lets you upload one of the provided TSV files, and the service will run it through a Machine Learning model hosted in ML Studio to try and predict the likelihood of failure.
* Any user connected to the site when an upload is finished will see the results, like magic.
* A user can "acknowledge" the alert about the potentially problematic compressor, this removes it from the view for everyone.


# Projet-Streamtouchdeck

Ce projet a pour but de créer un Streamdeck en utilisant un écran tactile sur Windows 10 et OBS.

Les Touchevent de Windows 10 font appelle à un MouseEvent, donc la souris se déplace au point d'appui sur l'écran tactile, et ne sont pas considérés comme des events à part entière.

En attendant que Microsoft termine son OS, ce projet est à l'arrêt.

Ce projet fonctionne via un websocket, ce qui est une abération vu que l'écran tactile est branché sur le PC de stream, il faudra donc changer cette solution à terme en utilisant et développant un plugin pour OBS.

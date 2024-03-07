Pet project where I test new way to make architecture of project

Ready:
Infrastructure: yes(90%);
Main menu: no(20%);
Core: no(10%);

The game will be composed by modules, where every module works by itself and can change current state to another. For a while here 2 game modules: "Main menu"(menu) and "Core". 
Every module must work without other, only one exception by now - changing states.

CommandServices - it's command pattern, but modified: every command saving on creating, that helps not lose data. For instance:
Full algorithm:
-Create command "Add coins"
-Show coins tweens
-Perform command

While tweens are working the player exit from app. If command not was saved the player will lose coins that must be got. 
CommandServices resolves this problem and at bootstrap(or in any another state) perform all actions what not was perofromed.
CommandService canm works wothout saving, as usual command pattern, it depends on type of commands. For example, command "Change state" must be not savable, otherwise after bootstrap game will go unpredictible.

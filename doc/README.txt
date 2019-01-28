***README***
This document will provide general documentatation and will be updated throughout the course of the semester

GIT
---------------------
Setup:
-Make an account on github (everyone on the team should already have done this together on day 1)
-I strongly recommend getting github desktop (if you know how to handle git otherwise, and want to do it that way, it's not necessary, but this file will assume you install it)
-Through github desktop, clone the repository from the link provided via discord (if you are reading this, you've already done this)

Main Commands:
git checkout : checks out a branch that you wish to work on. DO NOT WORK ON MASTER
git branch NAME : creates a branch from your current location with the name given
git checkout -b NAME : creates a branch with the name, and checks it out
git commit : will prompt you through committing files. DO NOT COMMIT TO MASTER. COMMIT TO SEPERATE BRANCHES
git add NAME : will add the file with given name to the commit. THIS DOES NOT COMMIT ITSELF, you still have to git commit afterwards
git merge NAME : will merge branch with name into your current branch. These changes will have to still be committed.
git push NAME : will psuh the branch upstream. Until you do this, only you will see the branches you make, afterwards everyone has access to them. If it asks you to set-upstream, follow the prompt given.

Typical workflow will be creating a branch, working on it, committing every time progress is made (that way work is always saved), and then pushing up after every work session. 
Then, every week or so (more frequently is better), we will merge all working code together, to ensure that it is still working. Unless you are certain about it, do not merge things without doing it as a team.

Disaster Strikes:
If you make a commit that you shouldn't have: git reset --HEAD^ will reset your branch back to before its last commit. You can then add only the changes you want, and then commit again (correctly this time hopefully)
If other major disaster strikes, contact Jaidin, I can help walk you through fixing it.

Other Notes:
-DO NOT MAKE PRIVATE BRANCHES
-PLEASE DO NOT MAKE PRIVATE BRANCHES
-PRIVATE BRANCHES ARE BAD, BECAUSE THEN OTHER PEOPLE CANNOT SEE THEM
-https://rubygarage.org/blog/most-basic-git-commands-with-examples provides a good guide to other commands
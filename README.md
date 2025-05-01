Git commands usage 

git init - for initilize the git in repo
git status - for checking the files that are added or not addded
git add . - for adding all files 
git add <file/name> -to stage the paticular files
git reset - to undo from staged changes
git restore --staged <file/name> - to restore a specific file 
git remote add origin "origin repository url" - to add a remote repository
git push -u origin master -to push the master branch to origin


#barnch operations

#checkout and create new branch
git checkout -b <new_branch_name>

#push the current branch
git push -u origin <branch_name>
<!-- OR -->
git push --set-upstram origin <branch_name>

<!-- #pulling the branch -->
git pull 



<!-- #adding new changes to branch or in stage -->
git add .
<!-- OR -->
git add <file_name>


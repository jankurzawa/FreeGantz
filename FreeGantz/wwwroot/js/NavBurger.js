const menuList = document.getElementsByClassName('menu')[0].children;
for (let i = 0; i < menuList.length; i++) {
    let link = menuList[i];
    if (link.children[0].href === document.URL) {
        link.className += 'active ';
    }
}

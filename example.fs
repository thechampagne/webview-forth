require webview.fs

false 0 webview-create dup

s\" Basic Example\0" drop webview-set-title drop dup

480 320 WEBVIEW-HINT-NONE webview-set-size drop dup

s\" Thanks for using webview!\0" drop webview-set-html drop dup 

webview-run drop

webview-destroy

bye
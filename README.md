# webview-forth

[![](https://img.shields.io/github/v/tag/thechampagne/webview-forth?label=version)](https://github.com/thechampagne/webview-forth/releases/latest) [![](https://img.shields.io/github/license/thechampagne/webview-forth)](https://github.com/thechampagne/webview-forth/blob/main/LICENSE)

(G)Forth binding for a tiny cross-platform **webview** library to build modern cross-platform GUIs.

<p align="center">
<img src="https://raw.githubusercontent.com/thechampagne/webview-forth/main/.github/assets/screenshot.png"/>
</p>

### Example

```fs
require webview.fs

false 0 webview-create dup

s\" Basic Example\0" drop webview-set-title drop dup

480 320 WEBVIEW-HINT-NONE webview-set-size drop dup

s\" Thanks for using webview!\0" drop webview-set-html drop dup 

webview-run drop

webview-destroy

bye
```

### API

```fs
webview-create            ( f addr -- addr )
webview-destroy           ( addr -- n )
webview-run               ( addr -- n )
webview_terminate         ( addr -- n )
webview_dispatch          ( addr func addr -- n )
webview_get_window        ( addr -- addr )
webview_get_native_handle ( addr u -- addr )
webview_set_title         ( addr c-addr -- n )
webview_set_size          ( addr u u u -- n )
webview_navigate          ( addr c-addr -- n )
webview_set_html          ( addr c-addr -- n )
webview_init              ( addr c-addr -- n )
webview_eval              ( addr c-addr -- n )
webview_bind              ( addr c-addr func addr -- n )
webview_unbind            ( addr c-addr -- n )
webview_return            ( addr c-addr n c-addr -- n )
webview_version           ( -- addr )
```

### References
 - [webview](https://github.com/webview/webview/tree/0.12.0) - **0.12.0**

### License

This repo is released under the [Apache License 2.0](https://github.com/thechampagne/webview-forth/blob/main/LICENSE).

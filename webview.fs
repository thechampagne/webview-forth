\ Copyright 2025 XXIV
\
\ Licensed under the Apache License, Version 2.0 (the "License");
\ you may not use this file except in compliance with the License.
\ You may obtain a copy of the License at
\
\     http:\www.apache.org/licenses/LICENSE-2.0
\
\ Unless required by applicable law or agreed to in writing, software
\ distributed under the License is distributed on an "AS IS" BASIS,
\ WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
\ See the License for the specific language governing permissions and
\ limitations under the License.
\
\ ------------------------------------------------------------------------
\
\ (G)Forth binding for a tiny cross-platform webview library to build
\ modern cross-platform GUIs.
\
\ API:
\ webview-create            ( f addr -- addr )
\ webview-destroy           ( addr -- n )
\ webview-run               ( addr -- n )
\ webview-terminate         ( addr -- n )
\ webview-dispatch          ( addr func addr -- n )
\ webview-get-window        ( addr -- addr )
\ webview-get-native_handle ( addr u -- addr )
\ webview-set-title         ( addr c-addr -- n )
\ webview-set-size          ( addr u u u -- n )
\ webview-navigate          ( addr c-addr -- n )
\ webview-set-html          ( addr c-addr -- n )
\ webview-init              ( addr c-addr -- n )
\ webview-eval              ( addr c-addr -- n )
\ webview-bind              ( addr c-addr func addr -- n )
\ webview-unbind            ( addr c-addr -- n )
\ webview-return            ( addr c-addr n c-addr -- n )
\ webview-version           ( -- addr )
c-library webview

s" webview" add-lib
\c #include <webview.h>

0 constant WEBVIEW-NATIVE-HANDLE-KIND-UI-WINDOW
1 constant WEBVIEW-NATIVE-HANDLE-KIND-UI-WIDGET
2 constant WEBVIEW-NATIVE-HANDLE-KIND-BROWSER-CONTROLLER

0 constant WEBVIEW-HINT-NONE
1 constant WEBVIEW-HINT-MIN
2 constant WEBVIEW-HINT-MAX
3 constant WEBVIEW-HINT-FIXED

-5 constant WEBVIEW-ERROR-MISSING-DEPENDENCY
-4 constant WEBVIEW-ERROR-CANCELED
-3 constant WEBVIEW-ERROR-INVALID-STATE
-2 constant WEBVIEW-ERROR-INVALID-ARGUMENT
-1 constant WEBVIEW-ERROR-UNSPECIFIED
0 constant WEBVIEW-ERROR-OK
1 constant WEBVIEW-ERROR-DUPLICATE
2 constant WEBVIEW-ERROR-NOT-FOUND

begin-structure webview-ver
    4 +field webview-ver-major
    4 +field webview-ver-minor
    4 +field webview-ver-patch
end-structure

begin-structure webview-version-info
    webview-ver +field webview-version-info-version
    32 +field webview-version-info-version-number
    48 +field webview-version-info-pre-release
    48 +field webview-version-info-build-metadata
end-structure

\ w: webview_t
\ e: webview_error_t
c-function webview-create webview_create                        n a -- a        \ (int, void*) -> w
c-function webview-destroy webview_destroy                      a -- n          \ (w) -> e
c-function webview-run webview_run                              a -- n          \ (w) -> e
c-function webview-terminate webview_terminate                  a -- n          \ (w) -> e
c-function webview-dispatch webview_dispatch                    a func a -- n   \ (w, void (*)(w, void*), void*) -> e
c-function webview-get-window webview_get_window                a -- a          \ (w) -> void*
c-function webview-get-native_handle webview_get_native_handle  a n -- a        \ (w, webview_native_handle_kind_t) -> void*
c-function webview-set-title webview_set_title                  a a -- n        \ (w, const char*) -> e
c-function webview-set-size webview_set_size                    a n n n -- n    \ (w, int, int, webview_hint_t) -> e
c-function webview-navigate webview_navigate                    a a -- n        \ (w, const char*) -> e
c-function webview-set-html webview_set_html                    a a -- n        \ (w, const char*) -> e
c-function webview-init webview_init                            a a -- n        \ (w, const char*) -> e
c-function webview-eval webview_eval                            a a -- n        \ (w, const char*) -> e
c-function webview-bind webview_bind                            a a func a -- n \ (w, const char*, void (*)(const char*,const char*, void*), void*) -> e
c-function webview-unbind webview_unbind                        a a -- n        \ (w, const char*) -> e
c-function webview-return webview_return                        a a n a -- n    \ (w, const char*, int, const char*) -> e
c-function webview-version webview_version                      -- a            \ () -> webview_version_info_t*

end-c-library

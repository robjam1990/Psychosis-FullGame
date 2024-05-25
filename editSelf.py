#!/usr/bin/env engine

import sys
import os
import subprocess
import platform
import shutil
import utils

class Editor(utils.editor.Editor):
    has_projects = True

    def get_editor_executable(self):
        """
        Returns the executable for the psychosis editor.
        Handles setup of necessary directories if not available.
        """
        # Try to get the editor executable from the environment variable
        editor_executable = os.environ.get("EDITOR")
        if editor_executable is not None:
            return editor_executable

        # Determine the directory of the editor based on the current script's location
        base_dir = os.path.abspath(os.path.dirname(os.path.dirname(__file__)))
        editor_dir = os.path.join(utils.fs.decode(base_dir), "editor")

        # Determine the platform and set the appropriate executable path
        if utils.windows:
            editor_executable = os.path.join(editor_dir, "editor-windows", "editor.exe")
        elif utils.macintosh:
            editor_executable = os.path.join(editor_dir, "Editor.app", "Contents", "MacOS", "editor")
        else:
            editor_executable = os.path.join(editor_dir, f"editor-linux-{platform.machine()}", "editor")

        # Setup the default .editor directory if it doesn't exist
        default_dot_editor = os.path.join(editor_dir, "default-dot-editor")
        dot_editor = os.path.join(editor_dir, ".editor")
        if not os.path.exists(dot_editor) and os.path.exists(default_dot_editor):
            shutil.copytree(default_dot_editor, dot_editor)

        return editor_executable

    def begin(self, new_window=False, **kwargs):
        """Initialize the editor instance with an empty list of arguments."""
        self.args = []

    def open_file(self, filename, line=None, **kwargs):
        """Append a file (and optionally a line number) to the arguments list."""
        if line:
            filename = f"{filename}:{line}"
        self.args.append(filename)

    def open_project(self, project):
        """Append a project to the arguments list."""
        self.args.append(project)

    def end(self, **kwargs):
        """Finalize and run the editor with the collected arguments."""
        editor_executable = self.get_editor_executable()
        self.args.reverse()  # Ensure the arguments are in the correct order
        args = [editor_executable] + self.args
        args = [utils.fs.encode(arg) for arg in args]
        subprocess.Popen(args)

def main():
    """Main function to initialize and run the editor."""
    editor_instance = Editor()
    editor_instance.begin()

    for filename in sys.argv[1:]:
        editor_instance.open_file(filename)

    editor_instance.end()

if __name__ == "__main__":
    main()

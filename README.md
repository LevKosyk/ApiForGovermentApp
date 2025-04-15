{
"event": "Configuration file loaded: /home/adminuser/venv/lib/python3.11/site-packages/readmeai/config/settings/ignore_list.toml",
"level": "info",
"logger": "readmeai.config.settings",
"timestamp": "2025-04-15T09:57:20.284770Z",
"filename": "settings.py",
"func_name": "_load_settings",
"lineno": 276
}
{
"event": "Configuration file loaded: /home/adminuser/venv/lib/python3.11/site-packages/readmeai/config/settings/languages.toml",
"level": "info",
"logger": "readmeai.config.settings",
"timestamp": "2025-04-15T09:57:20.303044Z",
"filename": "settings.py",
"func_name": "_load_settings",
"lineno": 276
}
{
"event": "Configuration file loaded: /home/adminuser/venv/lib/python3.11/site-packages/readmeai/config/settings/parsers.toml",
"level": "info",
"logger": "readmeai.config.settings",
"timestamp": "2025-04-15T09:57:20.315097Z",
"filename": "settings.py",
"func_name": "_load_settings",
"lineno": 276
}
{
"event": "Configuration file loaded: /home/adminuser/venv/lib/python3.11/site-packages/readmeai/config/settings/prompts.toml",
"level": "info",
"logger": "readmeai.config.settings",
"timestamp": "2025-04-15T09:57:20.324546Z",
"filename": "settings.py",
"func_name": "_load_settings",
"lineno": 276
}
{
"event": "Configuration file loaded: /home/adminuser/venv/lib/python3.11/site-packages/readmeai/config/settings/tool_config.toml",
"level": "info",
"logger": "readmeai.config.settings",
"timestamp": "2025-04-15T09:57:20.338567Z",
"filename": "settings.py",
"func_name": "_load_settings",
"lineno": 276
}
{
"event": "Configuration file loaded: /home/adminuser/venv/lib/python3.11/site-packages/readmeai/config/settings/tooling.toml",
"level": "info",
"logger": "readmeai.config.settings",
"timestamp": "2025-04-15T09:57:20.350163Z",
"filename": "settings.py",
"func_name": "_load_settings",
"lineno": 276
}
{
"event": "Pydantic settings: dict_keys(['config', 'ignore_list', 'languages', 'parsers', 'prompts', 'tool_config', 'tooling'])",
"level": "info",
"logger": "readmeai.cli.main",
"timestamp": "2025-04-15T09:57:20.358516Z",
"filename": "main.py",
"func_name": "main",
"lineno": 86
}
{
"event": "Repository settings: repository='https://github.com/LevKosyk/ApiForGovermentApp' full_name='LevKosyk/ApiForGovermentApp' host_domain='github.com' host='github' name='ApiForGovermentApp'",
"level": "info",
"logger": "readmeai.cli.main",
"timestamp": "2025-04-15T09:57:20.360025Z",
"filename": "main.py",
"func_name": "main",
"lineno": 87
}
{
"event": "LLM API settings: api='OPENAI' base_url='https://api.openai.com/v1/chat/completions' context_window=3900 encoder='cl100k_base' host_name=Url('https://api.openai.com/') localhost=Url('http://localhost:11434/') model='gpt-3.5-turbo' path='v1/chat/completions' temperature=0.1 tokens=699 top_p=0.9",
"level": "info",
"logger": "readmeai.cli.main",
"timestamp": "2025-04-15T09:57:20.360246Z",
"filename": "main.py",
"func_name": "main",
"lineno": 88
}
{
"event": "Total files analyzed: 19",
"level": "info",
"logger": "readmeai.__main__",
"timestamp": "2025-04-15T09:57:20.881675Z",
"filename": "__main__.py",
"func_name": "log_repository_context",
"lineno": 102
}
{
"event": "Metadata extracted: {'cicd': {}, 'containers': {}, 'documentation': {}, 'package_managers': {'nuget': 'ApiForGovermentApp/ApiForGovermentApp.csproj'}}",
"level": "info",
"logger": "readmeai.__main__",
"timestamp": "2025-04-15T09:57:20.881933Z",
"filename": "__main__.py",
"func_name": "log_repository_context",
"lineno": 103
}
{
"event": "Dependencies: ['nuget', 'apiforgovermentapp.http', 'launchsettings.json', 'apiforgovermentapp.sln', 'appsettings.json', 'csharp', 'appsettings.development.json']",
"level": "info",
"logger": "readmeai.__main__",
"timestamp": "2025-04-15T09:57:20.882123Z",
"filename": "__main__.py",
"func_name": "log_repository_context",
"lineno": 104
}
{
"event": "Languages: {'sln': 1, 'csproj': 1, 'json': 3, 'cs': 13, 'http': 1}",
"level": "info",
"logger": "readmeai.__main__",
"timestamp": "2025-04-15T09:57:20.882272Z",
"filename": "__main__.py",
"func_name": "log_repository_context",
"lineno": 105
}
Traceback (most recent call last):
File "/home/adminuser/venv/lib/python3.11/site-packages/readmeai/__main__.py", line 32, in error_handler
yield
File "/home/adminuser/venv/lib/python3.11/site-packages/readmeai/__main__.py", line 40, in readme_agent
asyncio.run(readme_generator(config, output_file))
File "/home/adminuser/.local/share/uv/python/cpython-3.11.10-linux-x86_64-gnu/lib/python3.11/asyncio/runners.py", line 190, in run
return runner.run(main)
^^^^^^^^^^^^^^^^
File "/home/adminuser/.local/share/uv/python/cpython-3.11.10-linux-x86_64-gnu/lib/python3.11/asyncio/runners.py", line 118, in run
return self._loop.run_until_complete(task)
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
File "/home/adminuser/.local/share/uv/python/cpython-3.11.10-linux-x86_64-gnu/lib/python3.11/asyncio/base_events.py", line 654, in run_until_complete
return future.result()
^^^^^^^^^^^^^^^
File "/home/adminuser/venv/lib/python3.11/site-packages/readmeai/__main__.py", line 55, in readme_generator
async with ModelFactory.get_backend(config, context).use_api() as llm:
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
File "/home/adminuser/venv/lib/python3.11/site-packages/readmeai/models/factory.py", line 41, in get_backend
return llm_service(config, context)
^^^^^^^^^^^^^^^^^^^^^^^^^^^^
File "/home/adminuser/venv/lib/python3.11/site-packages/readmeai/models/openai.py", line 31, in __init__
self._model_settings()
File "/home/adminuser/venv/lib/python3.11/site-packages/readmeai/models/openai.py", line 43, in _model_settings
self.client = openai.OpenAI(api_key=os.getenv("OPENAI_API_KEY"))
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
File "/home/adminuser/venv/lib/python3.11/site-packages/openai/_client.py", line 105, in __init__
raise OpenAIError(
openai.OpenAIError: The api_key client option must be set either by passing api_key to the client or by setting the OPENAI_API_KEY environment variable
The above exception was the direct cause of the following exception:
Traceback (most recent call last):
File "/home/adminuser/venv/bin/readmeai", line 8, in <module>
sys.exit(main())
^^^^^^
File "/home/adminuser/venv/lib/python3.11/site-packages/click/core.py", line 1157, in __call__
return self.main(*args, **kwargs)
^^^^^^^^^^^^^^^^^^^^^^^^^^
File "/home/adminuser/venv/lib/python3.11/site-packages/click/core.py", line 1078, in main
rv = self.invoke(ctx)
^^^^^^^^^^^^^^^^
File "/home/adminuser/venv/lib/python3.11/site-packages/click/core.py", line 1434, in invoke
return ctx.invoke(self.callback, **ctx.params)
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
File "/home/adminuser/venv/lib/python3.11/site-packages/click/core.py", line 783, in invoke
return __callback(*args, **kwargs)
^^^^^^^^^^^^^^^^^^^^^^^^^^^
File "/home/adminuser/venv/lib/python3.11/site-packages/readmeai/cli/main.py", line 90, in main
readme_agent(config=config, output_file=output)
File "/home/adminuser/venv/lib/python3.11/site-packages/readmeai/__main__.py", line 39, in readme_agent
with error_handler():
File "/home/adminuser/.local/share/uv/python/cpython-3.11.10-linux-x86_64-gnu/lib/python3.11/contextlib.py", line 158, in __exit__
self.gen.throw(typ, value, traceback)
File "/home/adminuser/venv/lib/python3.11/site-packages/readmeai/__main__.py", line 34, in error_handler
raise ReadmeGeneratorError(e) from e
readmeai.errors.ReadmeGeneratorError: Error generating README: The api_key client option must be set either by passing api_key to the client or by setting the OPENAI_API_KEY environment variable

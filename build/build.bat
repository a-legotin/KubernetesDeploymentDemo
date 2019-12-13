docker-compose -f "..\docker-compose.yml" -f "..\docker-compose.override.yml" -f "..\obj\Docker\docker-compose.vs.release.g.yml" --no-ansi build --force-rm --parallel

FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app

#Install debugger
RUN apt-get update
RUN apt-get install curl -y unzip
RUN curl -sSL https://aka.ms/getvsdbgsh | bash /dev/stdin -v latest -l /vsdbg

EXPOSE 80/tcp

#Keep the debugger container on
ENTRYPOINT ["tail", "-f", "/dev/null"]
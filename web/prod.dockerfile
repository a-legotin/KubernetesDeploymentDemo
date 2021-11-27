FROM node:16-alpine3.11 as build-deps
WORKDIR /usr/src/app
COPY . ./
RUN yarn install
RUN yarn run build

FROM node:16-alpine3.11
COPY --from=build-deps /usr/src/app/build /usr/src/app/build
RUN yarn global add serve
WORKDIR /usr/src/app/build
CMD serve -p 80 -s . 
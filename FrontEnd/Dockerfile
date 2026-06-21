# ----------- Build Stage -----------
FROM node:22-alpine AS builder
WORKDIR /app

ENV REACT_APP_API_URL=http://demo-api.swtcmn.id.vn
ENV PORT=3000

COPY package*.json yarn.lock ./
RUN corepack enable
RUN yarn install --frozen-lockfile

COPY . .
RUN yarn build

# ----------- Production Stage -----------
FROM node:22-alpine
WORKDIR /app

RUN npm install -g serve
COPY --from=builder /app/build ./build

EXPOSE 3000
CMD ["serve", "-s", "build", "-l", "3000"]
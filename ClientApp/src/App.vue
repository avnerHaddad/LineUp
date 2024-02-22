<template>
    <div id="app">
        <button @click="makeShavzak">Make Shavzak</button>
        <table v-if="shavzak">
            <thead>
                <tr>
                    <th>Day</th>
                    <th>Konan</th>
                    <th>Morning</th>
                    <th>Evening</th>
                    <th>Night</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="(day, index) in shavzak" :key="index">
                    <td>{{ day.day }}</td>
                    <td>{{ day.konan }}</td>
                    <td>{{ day.morning }}</td>
                    <td>{{ day.evening }}</td>
                    <td>{{ day.night }}</td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script>
    export default {
        data() {
            return {
                shavzak: null
            };
        },
        methods: {
            makeShavzak() {
                this.shavzak = [
                    { day: "Sunday", konan: "konan1", morning: "morning1", evening: "evening1", night: "night1" },
                    { day: "Monday", konan: "konan2", morning: "morning2", evening: "evening2", night: "night2" },
                    // Add more days as needed
                ];
            }
        }
    };
</script>

<style>
    #app {
        font-family: Avenir, Helvetica, Arial, sans-serif;
        -webkit-font-smoothing: antialiased;
        -moz-osx-font-smoothing: grayscale;
        text-align: center;
        color: #2c3e50;
        margin-top: 60px;
    }

    table {
        width: 100%;
        border-collapse: collapse;
        margin-top: 20px;
    }

    th, td {
        border: 1px solid #ddd;
        padding: 8px;
    }

    th {
        background-color: #f2f2f2;
    }

    tr:nth-child(even) {
        background-color: #f2f2f2;
    }
</style>
